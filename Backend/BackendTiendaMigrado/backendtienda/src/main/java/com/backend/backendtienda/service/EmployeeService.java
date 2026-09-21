package com.backend.backendtienda.service;

import com.backend.backendtienda.dto.EmployeeDTOs.CreateEmployee;
import com.backend.backendtienda.dto.EmployeeDTOs.GetEmployee;
import com.backend.backendtienda.dto.EmployeeDTOs.UpdateEmployee;
import com.backend.backendtienda.entity.Employee;
import com.backend.backendtienda.entity.Position;
import com.backend.backendtienda.repository.EmployeeRepository;
import com.backend.backendtienda.repository.PositionRepository;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;

@Service
public class EmployeeService {

    private final EmployeeRepository employeeRepository;
    private final PositionRepository positionRepository;

    public EmployeeService(EmployeeRepository employeeRepository,
                           PositionRepository positionRepository) {
        this.employeeRepository = employeeRepository;
        this.positionRepository = positionRepository;
    }

    @Transactional(readOnly = true)
    public List<GetEmployee> getAll() {
        return employeeRepository.findAll().stream()
                .map(this::toResponse)
                .toList();
    }

    @Transactional(readOnly = true)
    public GetEmployee getById(Integer id) {
        return toResponse(findEmployee(id));
    }

    @Transactional
    public void add(CreateEmployee req) {
        Employee employee = new Employee();
        employee.setFullName(req.fullName());
        employee.setEmail(req.email());
        employee.setBirthDate(req.birthDate());
        employee.setPosition(findPosition(req.positionId()));

        employeeRepository.save(employee);
    }

    @Transactional
    public void update(UpdateEmployee req) {
        Employee employee = findEmployee(req.employeeId());
        employee.setFullName(req.fullName());
        employee.setEmail(req.email());
        employee.setBirthDate(req.birthDate());
        employee.setPosition(findPosition(req.positionId()));
        // Hibernate guarda los cambios al terminar la transacción
    }

    @Transactional
    public void delete(Integer id) {
        employeeRepository.delete(findEmployee(id));
    }

    private Employee findEmployee(Integer id) {
        return employeeRepository.findById(id)
                .orElseThrow(() -> new ResponseStatusException(
                        HttpStatus.NOT_FOUND, "El empleado no existe"));
    }

    private Position findPosition(Integer id) {
        if (id == null) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "El puesto es obligatorio");
        }
        return positionRepository.findById(id)
                .orElseThrow(() -> new ResponseStatusException(
                        HttpStatus.BAD_REQUEST, "El puesto no existe"));
    }

    private GetEmployee toResponse(Employee e) {
        return new GetEmployee(
                e.getEmployeeId(),
                e.getFullName(),
                e.getEmail(),
                e.getBirthDate(),
                e.getPosition().getPositionId(),
                e.getPosition().getName());
    }
}