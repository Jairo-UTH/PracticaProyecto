package com.backend.backendtienda.entity;

import jakarta.persistence.*;
import java.time.LocalDate;

@Entity
@Table(name = "employee")
public class Employee {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "employeeid")
    private Integer employeeId;

    @Column(name = "fullname", nullable = false, length = 150)
    private String fullName;

    @Column(name = "email", length = 150)
    private String email;

    @Column(name = "birthdate")
    private LocalDate birthDate;

    // Solo lectura: la clave foránea se escribe a través de "position"
    @Column(name = "positionid", insertable = false, updatable = false)
    private Integer positionId;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "positionid", nullable = false)
    private Position position;

    public Employee() {
    }

    public Integer getEmployeeId() {
        return employeeId;
    }

    public void setEmployeeId(Integer employeeId) {
        this.employeeId = employeeId;
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public LocalDate getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(LocalDate birthDate) {
        this.birthDate = birthDate;
    }

    public Integer getPositionId() {
        return positionId;
    }

    public Position getPosition() {
        return position;
    }

    public void setPosition(Position position) {
        this.position = position;
    }
}