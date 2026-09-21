package com.backend.backendtienda.entity;

import jakarta.persistence.*;
import org.hibernate.annotations.CreationTimestamp;   // ← NUEVO

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "product")
public class Product {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "productid")
    private Integer productId;

    @ManyToOne
    @JoinColumn(name = "categoryid")
    private Category category;

    @Column(name = "name", length = 150)
    private String name;

    @Column(name = "price", precision = 18, scale = 2)
    private BigDecimal price;

    @Column(name = "stockquantity")
    private Integer stockQuantity;

    @Column(name = "image")
    private String image;

    @CreationTimestamp                                                   // ← NUEVO
    @Column(name = "createdat", nullable = false, updatable = false)     // ← MODIFICADO
    private LocalDateTime createdAt;

    @OneToMany(mappedBy = "product")
    private List<OrderDetail> orderDetails = new ArrayList<>();

    public Product() {
    }

    public Integer getProductId() {
        return productId;
    }

    public void setProductId(Integer productId) {
        this.productId = productId;
    }

    public Category getCategory() {
        return category;
    }

    public void setCategory(Category category) {
        this.category = category;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public Integer getStockQuantity() {
        return stockQuantity;
    }

    public void setStockQuantity(Integer stockQuantity) {
        this.stockQuantity = stockQuantity;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public LocalDateTime getCreatedAt() {
        return createdAt;
    }

    public void setCreatedAt(LocalDateTime createdAt) {
        this.createdAt = createdAt;
    }

    public List<OrderDetail> getOrderDetails() {
        return orderDetails;
    }

    public void setOrderDetails(List<OrderDetail> orderDetails) {
        this.orderDetails = orderDetails;
    }
}