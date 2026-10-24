package org.logi2564.ew4online;

import android.app.Activity;
import android.app.AlertDialog;
import android.os.Bundle;
import android.graphics.Color;
import android.content.ClipboardManager;
import android.content.ClipData;
import android.content.DialogInterface;
import android.view.Gravity;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.EditText;
import android.widget.Button;
import android.widget.Toast;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.webkit.WebResourceRequest;
import android.webkit.WebResourceError;
import android.webkit.WebSettings;
import android.util.Base64;
import org.json.JSONObject;
import java.net.URI;
import java.nio.charset.StandardCharsets;

public final class GameActivity extends Activity {
    private WebView game;
    private EditText invitation;
    private String origin;
    private String lastCode="";
    private int dp(float value) { return (int)(value * getResources().getDisplayMetrics().density + .5f); }
    @Override public void onCreate(Bundle saved) {
        super.onCreate(saved);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);
        getWindow().addFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
        if(BuildConfig.DEBUG)WebView.setWebContentsDebuggingEnabled(true);
        menu();
        String testInvite=getIntent().getStringExtra("invite");
        if(testInvite!=null)connect(testInvite);
    }
    private Button button(String text,LinearLayout box) {
        Button b=new Button(this);b.setText(text);b.setTextColor(Color.rgb(242,229,196));b.setBackgroundTintList(android.content.res.ColorStateList.valueOf(Color.rgb(53,74,53)));
        LinearLayout.LayoutParams lp=new LinearLayout.LayoutParams(-1,dp(48));lp.topMargin=dp(9);box.addView(b,lp);return b;
    }
    private void menu() {
        if(game!=null){game.stopLoading();game.destroy();game=null;}
        LinearLayout outer=new LinearLayout(this);outer.setOrientation(LinearLayout.VERTICAL);outer.setGravity(Gravity.CENTER);outer.setPadding(dp(26),dp(16),dp(26),dp(16));outer.setBackgroundColor(Color.rgb(29,33,26));
        LinearLayout box=new LinearLayout(this);box.setOrientation(LinearLayout.VERTICAL);outer.addView(box,new LinearLayout.LayoutParams(dp(420),-2));
        TextView title=new TextView(this);title.setText("EUROPEAN WAR 4 · NAPOLEON");title.setTextSize(23);title.setTextColor(Color.rgb(233,211,160));title.setGravity(Gravity.CENTER);box.addView(title);
        TextView help=new TextView(this);help.setText("Мультиплеер\nВставь код приглашения от друга с ПК");help.setTextSize(15);help.setTextColor(Color.LTGRAY);help.setGravity(Gravity.CENTER);box.addView(help);
        invitation=new EditText(this);invitation.setHint("EW4-…");invitation.setSingleLine(true);invitation.setTextColor(Color.WHITE);invitation.setHintTextColor(Color.GRAY);invitation.setTextSize(15);invitation.setId(1001);box.addView(invitation,new LinearLayout.LayoutParams(-1,dp(48)));
        Button paste=button("Вставить код",box);paste.setId(1002);paste.setOnClickListener(new View.OnClickListener(){public void onClick(View v){ClipboardManager clipboard=(ClipboardManager)getSystemService(CLIPBOARD_SERVICE);if(clipboard.hasPrimaryClip()){ClipData clip=clipboard.getPrimaryClip();if(clip!=null&&clip.getItemCount()>0)invitation.setText(clip.getItemAt(0).coerceToText(GameActivity.this));}}});
        Button play=button("Подключиться к игре",box);play.setId(1003);play.setOnClickListener(new View.OnClickListener(){public void onClick(View v){connect(invitation.getText().toString().trim());}});
        setContentView(outer);
    }
    private void connect(String code) {
        try {
            if(!code.startsWith("EW4-")||code.length()>1800)throw new IllegalArgumentException();
            JSONObject info=new JSONObject(new String(Base64.decode(code.substring(4),Base64.URL_SAFE|Base64.NO_WRAP|Base64.NO_PADDING),StandardCharsets.UTF_8));
            URI url=new URI(info.getString("u"));String token=info.getString("t");
            if(!"https".equals(url.getScheme())||url.getHost()==null||!url.getHost().endsWith(".trycloudflare.com")||url.getPort()!=-1||url.getUserInfo()!=null||!token.matches("[A-Fa-f0-9]{64}")||!("/".equals(url.getPath())||"".equals(url.getPath())))throw new IllegalArgumentException();
            origin="https://"+url.getHost();lastCode=code;
            game=new WebView(this);game.setId(1004);game.setBackgroundColor(Color.rgb(29,33,26));
            WebSettings settings=game.getSettings();settings.setJavaScriptEnabled(true);settings.setDomStorageEnabled(true);settings.setAllowFileAccess(false);settings.setAllowContentAccess(false);settings.setJavaScriptCanOpenWindowsAutomatically(false);settings.setSupportMultipleWindows(false);settings.setMixedContentMode(WebSettings.MIXED_CONTENT_NEVER_ALLOW);settings.setMediaPlaybackRequiresUserGesture(true);
            game.setWebViewClient(new WebViewClient(){
                @Override public boolean shouldOverrideUrlLoading(WebView view,WebResourceRequest request){return !allowed(request.getUrl().toString());}
                @Override public boolean shouldOverrideUrlLoading(WebView view,String url){return !allowed(url);}
                @Override public void onReceivedError(WebView view,WebResourceRequest request,WebResourceError error){if(request.isForMainFrame()){menu();invitation.setText(lastCode);Toast.makeText(GameActivity.this,"Нет связи с создателем. Проверь интернет и подключись снова.",Toast.LENGTH_LONG).show();}}
            });
            setContentView(game);game.loadUrl(origin+"/native#join="+token);
        } catch(Exception e) { Toast.makeText(this,"Нужен полный код приглашения EW4-… от создателя игры",Toast.LENGTH_LONG).show(); }
    }
    private boolean allowed(String value) {try{URI u=new URI(value);return "https".equals(u.getScheme())&&origin.equals("https://"+u.getHost())&&u.getUserInfo()==null&&u.getPort()==-1;}catch(Exception e){return false;}}
    @Override public void onBackPressed(){if(game==null){super.onBackPressed();return;}new AlertDialog.Builder(this).setTitle("Выйти из партии?").setMessage("Партия останется у создателя. Можно вернуться по прежнему коду.").setPositiveButton("В меню",new DialogInterface.OnClickListener(){public void onClick(DialogInterface d,int w){menu();}}).setNegativeButton("Продолжить",null).show();}
    @Override public void onDestroy(){if(game!=null){game.destroy();game=null;}super.onDestroy();}
}
