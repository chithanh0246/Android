package com.example.bmi_calculator;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.sql.Connection;
import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {
    EditText emaillogin , passwordlogin;
    Button loginbtn,regbtn;

    List<TaiKhoan> mList;
    TaiKhoan mUser;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        emaillogin = (EditText) findViewById(R.id.emaillogin);
        passwordlogin  =(EditText) findViewById(R.id.password);
        loginbtn = (Button) findViewById(R.id.loginbtn);
        regbtn =(Button) findViewById(R.id.regbtn);
        mList=new ArrayList<>();
        getListUsers();

        loginbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clickLogin();
            }
        });

    }

    private void clickLogin() {
        String email = emaillogin.getText().toString().trim();
        String pass = passwordlogin.getText().toString().trim();
        if(mList==null||mList.isEmpty()){
            return;

        }
        boolean isHasUser=false;
        for(TaiKhoan user:mList){
                if(email.equals(user.getEmail()) && pass.equals(user.getPass())){
                    isHasUser=true;
                    mUser=user;
                    break;
                }
        if(isHasUser==true){
            Intent intent=new Intent(LoginActivity.this,MainActivity.class);
            Bundle bundle= new Bundle();
            bundle.putSerializable("object_user",mUser);
            intent.putExtras(bundle);
            startActivity(intent);
        }else{
            Toast.makeText(LoginActivity.this,"Email or Password invalid",Toast.LENGTH_SHORT).show();

        }
        }
    }

    private void getListUsers(){
        ApiService.apiServices.getUser().enqueue(new Callback<TaiKhoan>() {
            @Override
            public void onResponse(Call<TaiKhoan> call, Response<TaiKhoan> response) {
                mList= (List<TaiKhoan>) response.body();
                Log.e("List Users",mList.size()+"");
            }

            @Override
            public void onFailure(Call<TaiKhoan> call, Throwable t) {
                Toast.makeText(LoginActivity.this,"Call api error",Toast.LENGTH_SHORT).show();
            }
        });
    }
}