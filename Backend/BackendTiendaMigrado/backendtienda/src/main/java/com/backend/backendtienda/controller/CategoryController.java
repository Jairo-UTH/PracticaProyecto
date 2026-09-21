package com.backend.backendtienda.controller;

import com.backend.backendtienda.dto.CategoryDTOs.GetCategoryResponse;
import com.backend.backendtienda.service.CategoryService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping({"/api/Category", "/api/category"})
public class CategoryController {

    private final CategoryService service;

    public CategoryController(CategoryService service) {
        this.service = service;
    }

    @GetMapping("/getAll")
    public ResponseEntity<List<GetCategoryResponse>> getAll() {
        return ResponseEntity.ok(service.getAll());
    }
}