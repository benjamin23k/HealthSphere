import { useEffect, useState } from "react";
import { doctorService, departmentService } from "../api/services";
import type { Doctor, Department } from "../types/models";

const empty: Partial<Doctor> = {
  firstName: "", lastName: "", specialty: "", licenseNumber: "", email: "", phone: "", departmentId: undefined,
};

export default function DoctorsPage() {
  const [items, setItems] = useState<Doctor[]>([]);
  const [departments, setDepartments] = useState<Department[]>([]);
  const [form, setForm] = useState<Partial<Doctor>>(empty);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [error, setError] = useState<string | null>(null);

  const load = async () => {
    setItems(await doctorService.getAll());
    setDepartments(await departmentService.getAll());
  };
  useEffect(() => { load(); }, []);

  const submit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    try {
      const payload = { ...form, departmentId: Number(form.departmentId) };
      if (editingId) await doctorService.update(editingId, payload);
      else await doctorService.create(payload);
      setForm(empty);
      setEditingId(null);
      await load();
    } catch (err: any) {
      setError(err?.response?.data?.message ?? "Error saving.");
    }
  };

  const edit = (d: Doctor) => { setForm(d); setEditingId(d.id); };
  const remove = async (id: number) => { if (confirm("Delete doctor?")) { await doctorService.remove(id); await load(); } };

  return (
    <div className="page">
      <h2>Doctors</h2>
      <form onSubmit={submit} className="form-row">
        <input placeholder="First Name" value={form.firstName ?? ""} onChange={e => setForm({ ...form, firstName: e.target.value })} required />
        <input placeholder="Last Name" value={form.lastName ?? ""} onChange={e => setForm({ ...form, lastName: e.target.value })} required />
        <input placeholder="Specialty" value={form.specialty ?? ""} onChange={e => setForm({ ...form, specialty: e.target.value })} required />
        <input placeholder="License Number" value={form.licenseNumber ?? ""} onChange={e => setForm({ ...form, licenseNumber: e.target.value })} required />
        <input placeholder="Email" value={form.email ?? ""} onChange={e => setForm({ ...form, email: e.target.value })} />
        <input placeholder="Phone" value={form.phone ?? ""} onChange={e => setForm({ ...form, phone: e.target.value })} />
        <select value={form.departmentId ?? ""} onChange={e => setForm({ ...form, departmentId: Number(e.target.value) })} required>
          <option value="">-- Select Department --</option>
          {departments.map(d => <option key={d.id} value={d.id}>{d.name}</option>)}
        </select>
        <button type="submit">{editingId ? "Update" : "Create"}</button>
        {editingId && <button type="button" onClick={() => { setForm(empty); setEditingId(null); }}>Cancel</button>}
      </form>
      {error && <p className="error">{error}</p>}
      <table>
        <thead><tr><th>Id</th><th>Name</th><th>Specialty</th><th>License</th><th>Department</th><th></th></tr></thead>
        <tbody>
          {items.map(d => (
            <tr key={d.id}>
              <td>{d.id}</td><td>{d.firstName} {d.lastName}</td><td>{d.specialty}</td><td>{d.licenseNumber}</td><td>{d.departmentName}</td>
              <td><button onClick={() => edit(d)}>Edit</button> <button onClick={() => remove(d.id)}>Delete</button></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
