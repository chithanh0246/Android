package com.example.bmi_calculator;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;

public class RegisterActivity extends AppCompatActivity {
    EditText name,password,email;
    Button registerbtn;
    TextView status;
ImageButton imgBack;
    Connection con;
    Statement stmt;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        name = (EditText) findViewById(R.id.name);
        password = (EditText) findViewById(R.id.password);
        email = (EditText) findViewById(R.id.email);
        registerbtn = (Button) findViewById(R.id.registerbtn);
        status = (TextView) findViewById(R.id.status);
        imgBack = (ImageButton) findViewById(R.id.imgBack);




    }
}