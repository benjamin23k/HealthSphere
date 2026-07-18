import { useEffect, useState } from "react";
import { departmentService } from "../api/services";
import type { Department } from "../types/models";

const empty: Partial<Department> = { name: "", description: "", location: "" };

export default function DepartmentsPage() {
  const [items, setItems] = useState<Department[]>([]);
  const [form, setForm] = useState<Partial<Department>>(empty);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [error, setError] = useState<string | null>(null);

  const load = async () => setItems(await departmentService.getAll());
  useEffect(() => { load(); }, []);

  const submit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    try {
      if (editingId) await departmentService.update(editingId, form);
      else await departmentService.create(form);
      setForm(empty);
      setEditingId(null);
      await load();
    } catch (err: any) {
      setError(err?.response?.data?.message ?? "Error saving.");
    }
  };

  const edit = (d: Department) => { setForm(d); setEditingId(d.id); };
  const remove = async (id: number) => { if (confirm("Delete department?")) { await departmentService.remove(id); await load(); } };

  return (
    <div className="page">
      <h2>Departments</h2>
      <form onSubmit={submit} className="form-row">
        <input placeholder="Name" value={form.name ?? ""} onChange={e => setForm({ ...form, name: e.target.value })} required />
        <input placeholder="Description" value={form.description ?? ""} onChange={e => setForm({ ...form, description: e.target.value })} />
        <input placeholder="Location" value={form.location ?? ""} onChange={e => setForm({ ...form, location: e.target.value })} />
        <button type="submit">{editingId ? "Update" : "Create"}</button>
        {editingId && <button type="button" onClick={() => { setForm(empty); setEditingId(null); }}>Cancel</button>}
      </form>
      {error && <p className="error">{error}</p>}
      <table>
        <thead><tr><th>Id</th><th>Name</th><th>Description</th><th>Location</th><th></th></tr></thead>
        <tbody>
          {items.map(d => (
            <tr key={d.id}>
              <td>{d.id}</td><td>{d.name}</td><td>{d.description}</td><td>{d.location}</td>
              <td><button onClick={() => edit(d)}>Edit</button> <button onClick={() => remove(d.id)}>Delete</button></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
