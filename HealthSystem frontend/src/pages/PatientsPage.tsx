import { useEffect, useState } from "react";
import { patientService, insuranceService } from "../api/services";
import type { Patient, Insurance } from "../types/models";

const empty: Partial<Patient> = {
  firstName: "", lastName: "", dateOfBirth: "", gender: "", email: "", phone: "", documentNumber: "", insuranceId: null,
};

export default function PatientsPage() {
  const [items, setItems] = useState<Patient[]>([]);
  const [insurances, setInsurances] = useState<Insurance[]>([]);
  const [form, setForm] = useState<Partial<Patient>>(empty);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [error, setError] = useState<string | null>(null);

  const load = async () => {
    setItems(await patientService.getAll());
    setInsurances(await insuranceService.getAll());
  };
  useEffect(() => { load(); }, []);

  const submit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    try {
      const payload = {
        ...form,
        insuranceId: form.insuranceId ? Number(form.insuranceId) : null,
      };
      if (editingId) await patientService.update(editingId, payload);
      else await patientService.create(payload);
      setForm(empty);
      setEditingId(null);
      await load();
    } catch (err: any) {
      setError(err?.response?.data?.message ?? "Error saving patient.");
    }
  };

  const edit = (p: Patient) => {
    setForm({ ...p, dateOfBirth: p.dateOfBirth?.substring(0, 10) });
    setEditingId(p.id);
  };
  const remove = async (id: number) => {
    if (confirm("Delete patient?")) { await patientService.remove(id); await load(); }
  };

  return (
    <div className="page">
      <h2>Patients</h2>
      <form onSubmit={submit} className="form-row">
        <input placeholder="First Name" value={form.firstName ?? ""} onChange={e => setForm({ ...form, firstName: e.target.value })} required />
        <input placeholder="Last Name" value={form.lastName ?? ""} onChange={e => setForm({ ...form, lastName: e.target.value })} required />
        <input type="date" value={form.dateOfBirth ?? ""} onChange={e => setForm({ ...form, dateOfBirth: e.target.value })} required />
        <select value={form.gender ?? ""} onChange={e => setForm({ ...form, gender: e.target.value })} required>
          <option value="">-- Gender --</option>
          <option value="Male">Male</option>
          <option value="Female">Female</option>
          <option value="Other">Other</option>
        </select>
        <input placeholder="Document Number" value={form.documentNumber ?? ""} onChange={e => setForm({ ...form, documentNumber: e.target.value })} required />
        <input placeholder="Email" value={form.email ?? ""} onChange={e => setForm({ ...form, email: e.target.value })} />
        <input placeholder="Phone" value={form.phone ?? ""} onChange={e => setForm({ ...form, phone: e.target.value })} />
        <select value={form.insuranceId ?? ""} onChange={e => setForm({ ...form, insuranceId: e.target.value ? Number(e.target.value) : null })}>
          <option value="">-- No Insurance --</option>
          {insurances.map(i => <option key={i.id} value={i.id}>{i.providerName}</option>)}
        </select>
        <button type="submit">{editingId ? "Update" : "Create"}</button>
        {editingId && <button type="button" onClick={() => { setForm(empty); setEditingId(null); }}>Cancel</button>}
      </form>
      {error && <p className="error">{error}</p>}
      <table>
        <thead><tr><th>Id</th><th>Name</th><th>Document Number</th><th>Date of Birth</th><th>Insurance</th><th></th></tr></thead>
        <tbody>
          {items.map(p => (
            <tr key={p.id}>
              <td>{p.id}</td><td>{p.firstName} {p.lastName}</td><td>{p.documentNumber}</td>
              <td>{p.dateOfBirth?.substring(0, 10)}</td><td>{p.insuranceProviderName ?? "-"}</td>
              <td><button onClick={() => edit(p)}>Edit</button> <button onClick={() => remove(p.id)}>Delete</button></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
