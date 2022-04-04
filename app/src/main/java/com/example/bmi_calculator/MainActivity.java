package com.example.bmi_calculator;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    Button calculatebmi;
    TextView currentage, currentweight , currentheight,txtUser;
    ImageView decrementweight , incrementweight ,decrementage , incrementage;
    SeekBar seekbarforheight;


    RelativeLayout mmale , mfemale;

    int intweight=55;
    int intage=21;
    int currentprogress;
    String mintprogress="170";
    String typeofuser="0";
    String weight2="50";
    String age2="21";




    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        getSupportActionBar().hide();

        txtUser = findViewById(R.id.user);
        calculatebmi = findViewById(R.id.calculatebmi);
        currentage = findViewById(R.id.currentage);
        currentweight = findViewById(R.id.currentweight);
        currentheight = findViewById(R.id.currentheight);
        decrementweight = findViewById(R.id.decrementweight);
        incrementweight = findViewById(R.id.incrementweight);
        decrementage = findViewById(R.id.decrementage);
        incrementage = findViewById(R.id.incrementage);
        seekbarforheight = findViewById(R.id.seekbarforheight);
        mmale=findViewById(R.id.male);
        mfemale=findViewById(R.id.female);
        Bundle bundleReceive=getIntent().getExtras();
        if(bundleReceive != null){
            TaiKhoan user= (TaiKhoan) bundleReceive.get("object_user");
            if(user != null){
                txtUser.setText(user.toString());
            }
        }


        mmale.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mmale.setBackground(ContextCompat.getDrawable(getApplicationContext(),R.drawable.malefemailefocus));
                mfemale.setBackground(ContextCompat.getDrawable(getApplicationContext(),R.drawable.malefemalenotfocus));
                typeofuser="Male";

            }
        });


        mfemale.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mfemale.setBackground(ContextCompat.getDrawable(getApplicationContext(),R.drawable.malefemailefocus));
                mmale.setBackground(ContextCompat.getDrawable(getApplicationContext(),R.drawable.malefemalenotfocus));
                typeofuser="Female";

            }
        });

        seekbarforheight.setMax(300);
        seekbarforheight.setProgress(170);
        seekbarforheight.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                currentprogress = progress;
                mintprogress = String.valueOf(currentprogress);
                currentheight.setText(mintprogress);
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });

        incrementage.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                intage = intage+1;
                age2 = String.valueOf(intage);
                currentage.setText(age2);
            }
        });

        decrementage.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                intage = intage-1;
                age2 = String.valueOf(intage);
                currentage.setText(age2);
            }
        });

        incrementweight.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                intweight = intweight+1;
                weight2 = String.valueOf(intweight);
                currentweight.setText(weight2);
            }
        });

        decrementweight.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                intweight = intweight-1;
                weight2 = String.valueOf(intweight);
                currentweight.setText(weight2);
            }
        });






        calculatebmi.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if(typeofuser.equals("0"))
                {
                    Toast.makeText(getApplicationContext(), "Select your gender first", Toast.LENGTH_LONG).show();

                }
                else if(mintprogress.equals("0"))
                {
                    Toast.makeText(getApplicationContext(), "select your height first " , Toast.LENGTH_LONG).show();
                }
                else if(intage==0 || intage<0)
                {
                    Toast.makeText(getApplicationContext(), "Age is incorrect" , Toast.LENGTH_LONG).show();
                }
                else if(intweight==0|| intweight<0)
                {
                    Toast.makeText(getApplicationContext(), "weight is incorrect " , Toast.LENGTH_LONG).show();
                }
                else
                    {
                        Intent intent = new Intent(MainActivity.this , bmiacvtivity.class);
                        intent.putExtra("gender" , typeofuser);
                        intent.putExtra("height" , mintprogress);
                        intent.putExtra("weight" , weight2);
                        intent.putExtra("age" , age2);


                        startActivity(intent);
                    }
                }



        });

    }
}