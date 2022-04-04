package com.example.bmi_calculator;

import java.io.Serializable;

public class TaiKhoan implements Serializable {
    private int IdTK;
    private String Email;
    private String Pass;
    private String HoTen;
    private int IdLoai;

    public int getIdTK() {
        return IdTK;
    }

    public void setIdTK(int idTK) {
        IdTK = idTK;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public String getPass() {
        return Pass;
    }

    public void setPass(String pass) {
        Pass = pass;
    }

    public String getHoTen() {
        return HoTen;
    }

    public void setHoTen(String hoTen) {
        HoTen = hoTen;
    }

    public int getIdLoai() {
        return IdLoai;
    }

    public void setIdLoai(int idLoai) {
        IdLoai = idLoai;
    }

    @Override
    public String toString() {
        return "TaiKhoan{" +
                "IdTK=" + IdTK +
                ", Email='" + Email + '\'' +
                ", Pass='" + Pass + '\'' +
                ", HoTen='" + HoTen + '\'' +
                ", IdLoai=" + IdLoai +
                '}';
    }
}
