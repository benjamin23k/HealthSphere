import { useEffect, useState } from "react";
import { insuranceService } from "../api/services";
import type { Insurance } from "../types/models";

const empty: Partial<Insurance> = { providerName: "", policyPrefix: "", coveragePercentage: 0, contactPhone: "" };

export default function InsurancesPage() {
  const [items, setItems] = useState<Insurance[]>([]);
  const [form, setForm] = useState<Partial<Insurance>>(empty);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [error, setError] = useState<string | null>(null);

  const load = async () => setItems(await insuranceService.getAll());
  useEffect(() => { load(); }, []);

  const submit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    try {
      if (editingId) await insuranceService.update(editingId, form);
      else await insuranceService.create(form);
      setForm(empty);
      setEditingId(null);
      await load();
    } catch (err: any) {
      setError(err?.response?.data?.message ?? "Error saving.");
    }
  };

  const edit = (i: Insurance) => { setForm(i); setEditingId(i.id); };
  const remove = async (id: number) => { if (confirm("Delete insurance?")) { await insuranceService.remove(id); await load(); } };

  return (
    <div className="page">
      <h2>Medical Insurances</h2>
      <form onSubmit={submit} className="form-row">
        <input placeholder="Insurance Provider" value={form.providerName ?? ""} onChange={e => setForm({ ...form, providerName: e.target.value })} required />
        <input placeholder="Policy Prefix" value={form.policyPrefix ?? ""} onChange={e => setForm({ ...form, policyPrefix: e.target.value })} />
        <input type="number" placeholder="% Coverage" value={form.coveragePercentage ?? 0}
          onChange={e => setForm({ ...form, coveragePercentage: Number(e.target.value) })} />
        <input placeholder="Phone" value={form.contactPhone ?? ""} onChange={e => setForm({ ...form, contactPhone: e.target.value })} />
        <button type="submit">{editingId ? "Update" : "Create"}</button>
        {editingId && <button type="button" onClick={() => { setForm(empty); setEditingId(null); }}>Cancel</button>}
      </form>
      {error && <p className="error">{error}</p>}
      <table>
        <thead><tr><th>Id</th><th>Provider</th><th>Prefix</th><th>% Coverage</th><th>Phone</th><th></th></tr></thead>
        <tbody>
          {items.map(i => (
            <tr key={i.id}>
              <td>{i.id}</td><td>{i.providerName}</td><td>{i.policyPrefix}</td><td>{i.coveragePercentage}%</td><td>{i.contactPhone}</td>
              <td><button onClick={() => edit(i)}>Edit</button> <button onClick={() => remove(i.id)}>Delete</button></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
