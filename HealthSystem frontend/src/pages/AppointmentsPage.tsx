import { useEffect, useState } from "react";
import { appointmentService, patientService, doctorService } from "../api/services";
import type { Appointment, Patient, Doctor } from "../types/models";
import { AppointmentStatusLabel } from "../types/models";

const empty: Partial<Appointment> = { patientId: undefined, doctorId: undefined, appointmentDate: "", reason: "" };

export default function AppointmentsPage() {
  const [items, setItems] = useState<Appointment[]>([]);
  const [patients, setPatients] = useState<Patient[]>([]);
  const [doctors, setDoctors] = useState<Doctor[]>([]);
  const [form, setForm] = useState<Partial<Appointment>>(empty);
  const [error, setError] = useState<string | null>(null);

  const load = async () => {
    setItems(await appointmentService.getAll());
    setPatients(await patientService.getAll());
    setDoctors(await doctorService.getAll());
  };
  useEffect(() => { load(); }, []);

  const submit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    try {
      await appointmentService.create({
        ...form,
        patientId: Number(form.patientId),
        doctorId: Number(form.doctorId),
      });
      setForm(empty);
      await load();
    } catch (err: any) {
      setError(err?.response?.data?.message ?? "Error creating the appointment.");
    }
  };

  const remove = async (id: number) => { if (confirm("Cancel/Delete appointment?")) { await appointmentService.remove(id); await load(); } };

  return (
    <div className="page">
      <h2>Citas medicas</h2>
      <form onSubmit={submit} className="form-row">
        <select value={form.patientId ?? ""} onChange={e => setForm({ ...form, patientId: Number(e.target.value) })} required>
          <option value="">-- Paciente --</option>
          {patients.map(p => <option key={p.id} value={p.id}>{p.firstName} {p.lastName}</option>)}
        </select>
        <select value={form.doctorId ?? ""} onChange={e => setForm({ ...form, doctorId: Number(e.target.value) })} required>
          <option value="">-- Doctor --</option>
          {doctors.map(d => <option key={d.id} value={d.id}>{d.firstName} {d.lastName} ({d.specialty})</option>)}
        </select>
        <input type="datetime-local" value={form.appointmentDate ?? ""} onChange={e => setForm({ ...form, appointmentDate: e.target.value })} required />
        <input placeholder="Reason" value={form.reason ?? ""} onChange={e => setForm({ ...form, reason: e.target.value })} />
        <button type="submit">Agendar</button>
      </form>
      {error && <p className="error">{error}</p>}
      <table>
        <thead><tr><th>Id</th><th>Paciente</th><th>Doctor</th><th>Fecha</th><th>Motivo</th><th>Estado</th><th></th></tr></thead>
        <tbody>
          {items.map(a => (
            <tr key={a.id}>
              <td>{a.id}</td><td>{a.patientFullName}</td><td>{a.doctorFullName}</td>
              <td>{new Date(a.appointmentDate).toLocaleString()}</td><td>{a.reason}</td>
              <td>{AppointmentStatusLabel[a.status]}</td>
              <td><button onClick={() => remove(a.id)}>Eliminar</button></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
