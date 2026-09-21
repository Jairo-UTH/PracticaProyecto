package com.backend.backendtienda.dto;

import java.time.LocalDate;

public final class EmployeeDTOs {

    private EmployeeDTOs() {
    }

    // ===== responses =====
    public record GetEmployee(
            Integer employeeId,
            String fullName,
            String email,
            LocalDate birthDate,
            Integer positionId,
            String position) {
    }

    // ===== requests =====
    public record CreateEmployee(
            String fullName,
            String email,
            LocalDate birthDate,
            Integer positionId) {
    }

    public record UpdateEmployee(
            Integer employeeId,
            String fullName,
            String email,
            LocalDate birthDate,
            Integer positionId) {
    }
}