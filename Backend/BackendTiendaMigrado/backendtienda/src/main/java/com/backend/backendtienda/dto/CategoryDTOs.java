package com.backend.backendtienda.dto;

public final class CategoryDTOs {

    private CategoryDTOs() {
    }

    // ===== responses =====
    public record GetCategoryResponse(String categoryId, String icon, String name) {
    }
}