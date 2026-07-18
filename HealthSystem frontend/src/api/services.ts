import { createCrudService } from "./crudService";
import type { Patient, Doctor, Department, Insurance, Appointment } from "../types/models";

export const patientService = createCrudService<Patient, Partial<Patient>, Partial<Patient>>("Patients");
export const doctorService = createCrudService<Doctor, Partial<Doctor>, Partial<Doctor>>("Doctors");
export const departmentService = createCrudService<Department, Partial<Department>, Partial<Department>>("Departments");
export const insuranceService = createCrudService<Insurance, Partial<Insurance>, Partial<Insurance>>("Insurances");
export const appointmentService = createCrudService<Appointment, Partial<Appointment>, Partial<Appointment>>("Appointments");
