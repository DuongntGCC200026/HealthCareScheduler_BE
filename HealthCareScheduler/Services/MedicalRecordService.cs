using AutoMapper;
using HealthCareScheduler.Dto.MedicalRecord;
using HealthCareScheduler.Dto.MedicalRecord;
using HealthCareScheduler.Dto.MedicalRecord;
using HealthCareScheduler.Dto.MedicalRecord;
using HealthCareScheduler.Exceptions;
using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories;
using HealthCareScheduler.Repositories.Interface;
using HealthCareScheduler.Services.Interface;

namespace HealthCareScheduler.Services
{
	public class MedicalRecordService : IMedicalRecordService
	{
		private readonly IMapper _mapper;
		private readonly IMedicalRecordRepository _medicalRecordRepository;

		public MedicalRecordService(IMapper mapper, IMedicalRecordRepository repository)
		{
			_mapper = mapper;
			_medicalRecordRepository = repository;
		}
		public MedicalRecordDto AddMedicalRecord(CreateMedicalRecordDto createMedicalRecordDto)
		{
			MedicalRecord medical = _mapper.Map<MedicalRecord>(createMedicalRecordDto);
			_medicalRecordRepository.CreateMedicalRecord(medical);

			return _mapper.Map<MedicalRecordDto>(medical);
		}

		public string DeleteMedicalRecord(Guid id)
		{
			MedicalRecord medicalRecord = _medicalRecordRepository.GetMedicalRecordById(id) ?? throw new NotFoundException("MedicalRecord does not exist");
			_medicalRecordRepository.DeleteMedicalRecord(medicalRecord);

			return "Delete successful";
		}

		public MedicalRecordDto GetMedicalRecordByAppointmentId(Guid id)
		{
			MedicalRecord medicalRecord = _medicalRecordRepository.GetMedicalRecordByAppointmentId(id) ?? throw new NotFoundException("MedicalRecord does not exist");

			return _mapper.Map<MedicalRecordDto>(medicalRecord);
		}

		public MedicalRecordDto GetMedicalRecordById(Guid id)
		{
			MedicalRecord medicalRecord = _medicalRecordRepository.GetMedicalRecordById(id) ?? throw new NotFoundException("MedicalRecord does not exist");

			return _mapper.Map<MedicalRecordDto>(medicalRecord);
		}

		public MedicalRecordDto UpdateMedicalRecord(Guid id, UpdateMedicalRecordDto updateMedicalRecordDto)
		{
			_ = _medicalRecordRepository.GetMedicalRecordById(id) ?? throw new NotFoundException("MedicalRecord does not exist");
			updateMedicalRecordDto.RecordId = id;

			MedicalRecord medicalRecordToUpdate = _mapper.Map<MedicalRecord>(updateMedicalRecordDto);
			_medicalRecordRepository.UpdateMedicalRecord(medicalRecordToUpdate);

			return _mapper.Map<MedicalRecordDto>(medicalRecordToUpdate);
		}
	}
}
