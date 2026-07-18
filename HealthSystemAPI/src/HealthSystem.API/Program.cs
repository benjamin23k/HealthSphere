using Microsoft.EntityFrameworkCore;
using PatientSystem.API.Middleware;
using PatientSystem.Business.Interfaces;
using PatientSystem.Business.Mapping;
using PatientSystem.Business.Services;
using PatientSystem.DataAccess;
using PatientSystem.Domain.Entities;
using PatientSystem.DTOs;
using  PatientSystem.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Patient System API",
        Version = "v1"
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddDbContext<PatientSystemDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IBaseCrudService<DepartmentReadDto, DepartmentCreateDto, DepartmentUpdateDto>>(sp =>
    new BaseCrudService<Department, DepartmentReadDto, DepartmentCreateDto, DepartmentUpdateDto>(
        sp.GetRequiredService<IUnitOfWork>().Departments,
        sp.GetRequiredService<IUnitOfWork>(),
        sp.GetRequiredService<AutoMapper.IMapper>()));

builder.Services.AddScoped<IBaseCrudService<InsuranceReadDto, InsuranceCreateDto, InsuranceUpdateDto>>(sp =>
    new BaseCrudService<Insurance, InsuranceReadDto, InsuranceCreateDto, InsuranceUpdateDto>(
        sp.GetRequiredService<IUnitOfWork>().Insurances,
        sp.GetRequiredService<IUnitOfWork>(),
        sp.GetRequiredService<AutoMapper.IMapper>()));

builder.Services.AddScoped<IBaseCrudService<AddressReadDto, AddressCreateDto, AddressUpdateDto>>(sp =>
    new BaseCrudService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>(
        sp.GetRequiredService<IUnitOfWork>().Addresses,
        sp.GetRequiredService<IUnitOfWork>(),
        sp.GetRequiredService<AutoMapper.IMapper>()));

builder.Services.AddScoped<IBaseCrudService<MedicalRecordReadDto, MedicalRecordCreateDto, MedicalRecordUpdateDto>>(sp =>
    new BaseCrudService<MedicalRecord, MedicalRecordReadDto, MedicalRecordCreateDto, MedicalRecordUpdateDto>(
        sp.GetRequiredService<IUnitOfWork>().MedicalRecords,
        sp.GetRequiredService<IUnitOfWork>(),
        sp.GetRequiredService<AutoMapper.IMapper>()));

builder.Services.AddScoped<IBaseCrudService<DiagnosisReadDto, DiagnosisCreateDto, DiagnosisUpdateDto>>(sp =>
    new BaseCrudService<Diagnosis, DiagnosisReadDto, DiagnosisCreateDto, DiagnosisUpdateDto>(
        sp.GetRequiredService<IUnitOfWork>().Diagnoses,
        sp.GetRequiredService<IUnitOfWork>(),
        sp.GetRequiredService<AutoMapper.IMapper>()));

builder.Services.AddScoped<IBaseCrudService<TreatmentReadDto, TreatmentCreateDto, TreatmentUpdateDto>>(sp =>
    new BaseCrudService<Treatment, TreatmentReadDto, TreatmentCreateDto, TreatmentUpdateDto>(
        sp.GetRequiredService<IUnitOfWork>().Treatments,
        sp.GetRequiredService<IUnitOfWork>(),
        sp.GetRequiredService<AutoMapper.IMapper>()));

builder.Services.AddScoped<IBaseCrudService<MedicationReadDto, MedicationCreateDto, MedicationUpdateDto>>(sp =>
    new BaseCrudService<Medication, MedicationReadDto, MedicationCreateDto, MedicationUpdateDto>(
        sp.GetRequiredService<IUnitOfWork>().Medications,
        sp.GetRequiredService<IUnitOfWork>(),
        sp.GetRequiredService<AutoMapper.IMapper>()));

builder.Services.AddScoped<IBaseCrudService<PrescriptionReadDto, PrescriptionCreateDto, PrescriptionUpdateDto>>(sp =>
    new BaseCrudService<Prescription, PrescriptionReadDto, PrescriptionCreateDto, PrescriptionUpdateDto>(
        sp.GetRequiredService<IUnitOfWork>().Prescriptions,
        sp.GetRequiredService<IUnitOfWork>(),
        sp.GetRequiredService<AutoMapper.IMapper>()));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<PatientSystemDbContext>();
        PatientSystem.API.DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error.");
    }
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();