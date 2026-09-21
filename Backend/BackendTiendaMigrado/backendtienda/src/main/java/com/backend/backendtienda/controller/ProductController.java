package com.backend.backendtienda.controller;

import com.backend.backendtienda.dto.ProductDTOs.CreateProductRequest;
import com.backend.backendtienda.dto.ProductDTOs.GetProductResponse;
import com.backend.backendtienda.dto.ProductDTOs.ReturnProductRequest;
import com.backend.backendtienda.service.ProductService;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;

import java.util.List;

@RestController
@RequestMapping({"/api/Product", "/api/product"})
public class ProductController {

    private final ProductService service;

    public ProductController(ProductService service) {
        this.service = service;
    }

    @PostMapping(value = "/create", consumes = MediaType.MULTIPART_FORM_DATA_VALUE)
    public ResponseEntity<Integer> create(@ModelAttribute CreateProductRequest request) {
        return ResponseEntity.ok(service.create(request));
    }

    @GetMapping("/getAll")
    public ResponseEntity<List<GetProductResponse>> getAll(@ModelAttribute ReturnProductRequest request) {
        String url = ServletUriComponentsBuilder.fromCurrentContextPath().toUriString();
        return ResponseEntity.ok(service.getAll(url, request.categoryId()));
    }
}