package com.example.bmi_calculator;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.bmi_calculator.Connection.ConnectionClass;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

public class LoginActivity extends AppCompatActivity {
    EditText emaillogin , passwordlogin;
    Button loginbtn,regbtn;
    Connection con ;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        emaillogin = (EditText) findViewById(R.id.emaillogin);
        passwordlogin  =(EditText) findViewById(R.id.password);
        loginbtn = (Button) findViewById(R.id.loginbtn);
        regbtn =(Button) findViewById(R.id.regbtn);

        loginbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                new LoginActivity.checkLogin().execute("");
            }
        });
        regbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LoginActivity.this,RegisterActivity.class);
                startActivity(intent);
                finish();
            }
        });
    }

    public class  checkLogin extends AsyncTask<String,String,String> {
        String z = null;
        Boolean isSuccess=false;
        @Override
        protected void onPreExecute() {

        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
        }

        @Override
        protected String doInBackground(String... strings) {
            con=connectionClass(ConnectionClass.un.toString(),ConnectionClass.pass.toString(),ConnectionClass.db.toString(),ConnectionClass.ip.toString());
            if(con==null){
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        Toast.makeText(LoginActivity.this,"Check Internet Connection",Toast.LENGTH_LONG).show();
                    }
                });
                z="On Internet Connection";
            }
            else {
                try {
                    String sql = "select * from Account where Email='"+ emaillogin.getText() +"'and Pass='"+ passwordlogin.getText() +"'";
                    Statement stmt = con.createStatement();
                    ResultSet rs = stmt.executeQuery(sql);
                    if (rs.next()) {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                Toast.makeText(LoginActivity.this, "Login Success", Toast.LENGTH_LONG).show();
                            }
                        });
                        z="Success";
                        Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                        startActivity(intent);
                        finish();
                    } else {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                Toast.makeText(LoginActivity.this, "Check email or password", Toast.LENGTH_LONG).show();
                            }
                        });
                        emaillogin.setText("");
                        passwordlogin.setText("");
                    }
                } catch (Exception e) {
                    isSuccess = false;
                    Log.e("SQL Error:", e.getMessage());

                }
            }
            return z;
        }
    }

    @SuppressLint("NewApi")
    public Connection connectionClass(String user,String pass,String database,String server){
        StrictMode.ThreadPolicy policy=new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        Connection connection=null;
        String connectionUrl = null;
        try {
            Class.forName("net.sourceforge.jtds.jdbc.Driver");
            connectionUrl="jdbc:jtds:sqlserver://"+server+"/"+database+";user="+user+";password="+pass+";";
            connection= DriverManager.getConnection(connectionUrl);

        }catch (Exception e){
            Log.e("SQL connect Error:",e.getMessage());
        }
        return connection;
    }
}