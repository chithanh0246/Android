package com.example.bmi_calculator;


import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.List;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.GET;

/*http://127.0.0.1:8560/api/taikhoan/gettaikhoans*/
public interface ApiService {

    Gson gson= new GsonBuilder()
            .setDateFormat("yyyy-MM-dd HH:mm:ss")
            .create();
    ApiService apiServices = new Retrofit.Builder()
            .baseUrl("http://10.0.2.2:8560/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
            .create(ApiService.class);
    @GET("api/taikhoan/gettaikhoans")
    Call<TaiKhoan> getUser();

}
