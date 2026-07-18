using AutoMapper;
using PatientSystem.Domain.Entities;
using PatientSystem.DTOs;

namespace PatientSystem.Business.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Department, DepartmentReadDto>();
        CreateMap<DepartmentCreateDto, Department>();
        CreateMap<DepartmentUpdateDto, Department>();

        CreateMap<Insurance, InsuranceReadDto>();
        CreateMap<InsuranceCreateDto, Insurance>();
        CreateMap<InsuranceUpdateDto, Insurance>();

        CreateMap<Doctor, DoctorReadDto>()
            .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Department != null ? s.Department.Name : null));
        CreateMap<DoctorCreateDto, Doctor>();
        CreateMap<DoctorUpdateDto, Doctor>();

        CreateMap<Address, AddressReadDto>();
        CreateMap<AddressCreateDto, Address>();
        CreateMap<AddressUpdateDto, Address>();

        CreateMap<Patient, PatientReadDto>()
            .ForMember(d => d.InsuranceProviderName, opt => opt.MapFrom(s => s.Insurance != null ? s.Insurance.ProviderName : null));
        CreateMap<PatientCreateDto, Patient>();
        CreateMap<PatientUpdateDto, Patient>();

        CreateMap<Appointment, AppointmentReadDto>()
            .ForMember(d => d.PatientFullName, opt => opt.MapFrom(s => s.Patient != null ? $"{s.Patient.FirstName} {s.Patient.LastName}" : null))
            .ForMember(d => d.DoctorFullName, opt => opt.MapFrom(s => s.Doctor != null ? $"{s.Doctor.FirstName} {s.Doctor.LastName}" : null));
        CreateMap<AppointmentCreateDto, Appointment>();
        CreateMap<AppointmentUpdateDto, Appointment>();

        CreateMap<MedicalRecord, MedicalRecordReadDto>()
            .ForMember(d => d.PatientFullName, opt => opt.MapFrom(s => s.Patient != null ? $"{s.Patient.FirstName} {s.Patient.LastName}" : null));
        CreateMap<MedicalRecordCreateDto, MedicalRecord>();
        CreateMap<MedicalRecordUpdateDto, MedicalRecord>();

        CreateMap<Diagnosis, DiagnosisReadDto>();
        CreateMap<DiagnosisCreateDto, Diagnosis>();
        CreateMap<DiagnosisUpdateDto, Diagnosis>();

        CreateMap<Treatment, TreatmentReadDto>();
        CreateMap<TreatmentCreateDto, Treatment>();
        CreateMap<TreatmentUpdateDto, Treatment>();

        CreateMap<Medication, MedicationReadDto>();
        CreateMap<MedicationCreateDto, Medication>();
        CreateMap<MedicationUpdateDto, Medication>();

        CreateMap<Prescription, PrescriptionReadDto>()
            .ForMember(d => d.MedicationName, opt => opt.MapFrom(s => s.Medication != null ? s.Medication.Name : null));
        CreateMap<PrescriptionCreateDto, Prescription>();
        CreateMap<PrescriptionUpdateDto, Prescription>();
    }
}
