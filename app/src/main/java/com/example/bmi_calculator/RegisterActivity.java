package com.example.bmi_calculator;

import android.annotation.SuppressLint;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.example.bmi_calculator.Connection.ConnectionClass;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;

public class RegisterActivity extends AppCompatActivity {
    EditText name,password,email;
    Button registerbtn;
    TextView status;

    Connection con;
    Statement stmt;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        name = (EditText) findViewById(R.id.name);
        password=(EditText) findViewById(R.id.password);
        email=(EditText) findViewById(R.id.email);
        registerbtn=(Button) findViewById(R.id.registerbtn);
        status=(TextView) findViewById(R.id.status);

        registerbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                new RegisterActivity.registeruser().execute("");
            }
        });
    }
    public class registeruser extends AsyncTask<String,String ,String> {
        String z= "";
        Boolean IsSuccess=false;

        @Override
        protected void onPreExecute() {
            status.setText("Sending data to database");

        }

        @Override
        protected void onPostExecute(String s) {
            status.setText("Registration Successful");
            name.setText("");
            email.setText("");
            password.setText("");
        }

        @Override
        protected String doInBackground(String... strings) {
            try {
                con=connectionClass(ConnectionClass.un.toString(),ConnectionClass.pass.toString(),ConnectionClass.db.toString(),ConnectionClass.ip.toString());
                if(con==null){
                    z="Check Your Internet Connection";
                }
                else {
                    String sql="insert into Account(Email,Pass,FullName) values ('"+email.getText()+"','"+password.getText()+"','"+name.getText()+"')";
                    stmt = con.createStatement();
                    stmt.executeQuery(sql);
                }
            }catch (Exception e){
                IsSuccess=false;
                z= e.getMessage();
            }


            return z;
        }
    }

    @SuppressLint("NewApi")
    public Connection  connectionClass(String user,String pass,String database,String server){
        StrictMode.ThreadPolicy policy=new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        Connection connection=null;
        String connectionUrl=null;
        try {
            Class.forName("net.sourceforge.jtds.jdbc.Driver");
            connectionUrl="jdbc:jtds:sqlserver://"+server+"/"+database+";user="+user+";password="+pass+"; ";
            connection= DriverManager.getConnection(connectionUrl);
        }catch (Exception e){
            Log.e("SQL Connection Error:",e.getMessage());
        }
        return connection;
    }
}