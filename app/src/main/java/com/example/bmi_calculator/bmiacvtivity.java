package com.example.bmi_calculator;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.text.Html;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

public class bmiacvtivity extends AppCompatActivity {

    Button recalculatebmi;

    TextView bmidisplay , bmicategory , gender;

    Intent intent;
    ImageView imageView;
    String mbmi;
    float intbmi;
    String height;
    String weight;
    float intheight , intweight;
    RelativeLayout mbackground;







    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bmiacvtivity);

        getSupportActionBar().setElevation(0);
        getSupportActionBar().setTitle(Html.fromHtml("<font color=\"white\"><font>"));
        getSupportActionBar().setTitle("Result");
        ColorDrawable colorDrawable = new ColorDrawable(Color.parseColor("#1E1D1D"));
        getSupportActionBar().setBackgroundDrawable(colorDrawable);


        intent=getIntent();
        bmidisplay=findViewById(R.id.bmidisplay);
        bmicategory=findViewById(R.id.bmicategory);
        gender=findViewById(R.id.genderdisplay);
        mbackground=findViewById(R.id.contentlayout);
        imageView=findViewById(R.id.imageview);
        recalculatebmi=findViewById(R.id.recalculatebmi);

        height=intent.getStringExtra("height");
        weight=intent.getStringExtra("weight");

        intheight=Float.parseFloat(height);
        intweight=Float.parseFloat(weight);

        intheight=intheight/100;

        intbmi=intweight/(intheight*intheight);

        mbmi=Float.toString(intbmi);

        if(intbmi<16)
        {
            bmicategory.setText("Gầy độ 3");
            mbackground.setBackgroundColor(Color.RED);
            imageView.setImageResource(R.drawable.crosss);
        }
        else if(intbmi<16.9 && intbmi>16)
        {
            bmicategory.setText("Gầy độ 2");
            mbackground.setBackgroundColor(Color.RED);
            imageView.setImageResource(R.drawable.warning);
        }else if(intbmi<18.4 && intbmi>17)
        {
            bmicategory.setText("Gầy độ 1");
            mbackground.setBackgroundColor(Color.RED);
            imageView.setImageResource(R.drawable.warning);
        }else if(intbmi<25 && intbmi>18.4)
        {
            bmicategory.setText("Cân đối");
            mbackground.setBackgroundColor(Color.GREEN);
            imageView.setImageResource(R.drawable.ok);
        }else if(intbmi<29.4 && intbmi>25)
        {
            bmicategory.setText("Thừa cân ");
            mbackground.setBackgroundColor(Color.RED);
            imageView.setImageResource(R.drawable.crosss);
        }
        else if(intbmi<35 && intbmi>30)
        {
            bmicategory.setText("Béo phì độ 1");
            mbackground.setBackgroundColor(Color.RED);
            imageView.setImageResource(R.drawable.warning);
        }
        else if(intbmi<40 && intbmi>35)
        {
            bmicategory.setText("Béo phì độ 2");
            mbackground.setBackgroundColor(Color.RED);
            imageView.setImageResource(R.drawable.warning);
        }
        else{
            bmicategory.setText("Béo phì độ 3");
            mbackground.setBackgroundColor(Color.RED);
            imageView.setImageResource(R.drawable.warning);
        }

        gender.setText(intent.getStringExtra("gender"));
        bmidisplay.setText(mbmi);



        recalculatebmi = findViewById(R.id.recalculatebmi);

        recalculatebmi.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(bmiacvtivity.this , MainActivity.class);
                startActivity(intent);
                finish();
            }
        });
    }
}