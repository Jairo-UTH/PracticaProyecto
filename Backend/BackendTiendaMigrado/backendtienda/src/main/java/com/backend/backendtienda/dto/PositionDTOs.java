package com.backend.backendtienda.dto;

public final class PositionDTOs {

    private PositionDTOs() {
    }

    public record GetPosition(Integer positionId, String name) {
    }
}