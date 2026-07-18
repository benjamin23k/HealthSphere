// Tipos que reflejan los DTOs expuestos por la API .NET.

export interface ApiResponse<T> {
  success: boolean;
  message?: string;
  data: T;
}

export interface Department {
  id: number;
  name: string;
  description?: string;
  location?: string;
}

export interface Insurance {
  id: number;
  providerName: string;
  policyPrefix?: string;
  coveragePercentage: number;
  contactPhone?: string;
}

export interface Doctor {
  id: number;
  firstName: string;
  lastName: string;
  specialty: string;
  licenseNumber: string;
  email?: string;
  phone?: string;
  departmentId: number;
  departmentName?: string;
}

export interface Patient {
  id: number;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  gender: string;
  email?: string;
  phone?: string;
  documentNumber: string;
  insuranceId?: number | null;
  insuranceProviderName?: string;
}

export const AppointmentStatus = {
  Scheduled: 0,
  Completed: 1,
  Cancelled: 2,
  NoShow: 3,
} as const;

export const AppointmentStatusLabel: Record<number, string> = {
  0: "Programada",
  1: "Completada",
  2: "Cancelada",
  3: "No asistio",
};

export interface Appointment {
  id: number;
  patientId: number;
  patientFullName?: string;
  doctorId: number;
  doctorFullName?: string;
  appointmentDate: string;
  reason?: string;
  status: number;
}
