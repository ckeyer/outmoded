{{define "blogHead"}}
<html lang="zh-cn">
  <head>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="OPENCS--204">
    <meta name="author" content="CJ_Studio">

    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../static/img/psu.jpg">
    <link rel="shortcut icon" href="../static/img/psu.jpg">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link href="../static/css/bootstrap.css" rel="stylesheet">
    <link href="../static/css/mainHeader.css" rel="stylesheet" type="text/css" />

    <script>
    var def = "3";

    function mover(object) {
        //主菜单
        var mm = document.getElementById("m_" + object);
        mm.className = "m_li_a";
        //初始主菜单先隐藏效果
        if (def != 0) {
            var mdef = document.getElementById("m_" + def);
            mdef.className = "m_li";
        }
        //子菜单
        var ss = document.getElementById("s_" + object);
        ss.style.display = "block";
        //初始子菜单先隐藏效果
        if (def != 0) {
            var sdef = document.getElementById("s_" + def);
            sdef.style.display = "none";
        }
    }

    function mout(object) {
        //主菜单
        var mm = document.getElementById("m_" + object);
        mm.className = "m_li";
        //初始主菜单还原效果
        if (def != 0) {
            var mdef = document.getElementById("m_" + def);
            mdef.className = "m_li_a";
        }
        //子菜单
        var ss = document.getElementById("s_" + object);
        ss.style.display = "none";
        //初始子菜单还原效果
        if (def != 0) {
            var sdef = document.getElementById("s_" + def);
            sdef.style.display = "block";
        }
    }
    </script> 
{{end}}

{{define "blogHeader"}}
    <header>
      <div id ="mainHeader1">
        <div id="menu"> 
          <div id = "menuLeft"> 
              <img src="../static/img/line1.gif" />
              <a class="m_login" href="#">OPENCS-LOGO</a>
              <img src="../static/img/line1.gif" />
          </div>
          <div id = "menuRight"> 
              <a class="m_login" href="/login">登录</a>
              <img src="../static/img/line1.gif"/>
              <img src="../static/img/line1.gif"/>
              <a class="m_login" href="/sign">注册</a>
          </div>
          <div id = "menuCenter">
            <ul>
              <li class="m_line">
                <img src="../static/img/line1.gif" />
              </li>
              <li id="m_1" class='m_li' onmouseover='mover(1);' onmouseout='mout(1);'>
                <a href="/">首页</a>
              </li>
              <li class="m_line">
                <img src="../static/img/line1.gif" />
              </li>
              <li id="m_2" class='m_li' onmouseover='mover(2);' onmouseout='mout(2);'>
                <a href="/forum">论坛</a>
              </li>
              <li class="m_line">
                <img src="../static/img/line1.gif" />
              </li>
              <li id="m_3" class='m_li_a'>
                <a href="/blog">博客</a>
              </li>
              <li class="m_line">
                <img src="../static/img/line1.gif" />
              </li>
              <li id="m_4" class='m_li' onmouseover='mover(4);' onmouseout='mout(4);'>
                <a href="/video">微视频</a>
              </li>
              <li class="m_line">
                <img src="../static/img/line1.gif" />
              </li>
              <li id="m_5" class='m_li' onmouseover='mover(5);' onmouseout='mout(5);'>
                <a href="/notice">站内公告</a>
              </li>
              <li class="m_line">
                <img src="../static/img/line1.gif" />
              </li>
              <li id="m_6" class='m_li' onmouseover='mover(6);' onmouseout='mout(6);'>
                <a href="/jour">战地日记</a>
              </li>
              <li class="m_line">
                <img src="../static/img/line1.gif" />
              </li>
              <li id="m_7" class='m_li' onmouseover='mover(7);' onmouseout='mout(7);'>
                <a href="lab204">Lab204</a>
              </li>
              <li class="m_line">
                <img src="../static/img/line1.gif" />
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div id = "mainHeader2">
        <div id="mainTop2" style="height:32px; background-color:#F1F1F1;">
          <ul class="smenu">
          <li style="padding-left:29px;" id="s_1" class='s_li'  onmouseover='mover(1);' onmouseout='mout(1);'>
            欢迎光临CJStudio开源小站，您是本站第
            <font color="red">2842</font>
            位客人！
          </li>
          <li style="padding-left:141px;" id="s_2" class='s_li' onmouseover='mover(2);' onmouseout='mout(2);'>
            <a href="/forum">论坛首页</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">编程开发</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">系统运维</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">数据库</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">网络</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">硬件相关</a>
          </li>
          <li style="padding-left:252px;" id="s_3" class='s_li_a'>
            <a href="/blog">博客首页</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">编程开发</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">系统运维</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">数据库</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">网络</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">硬件相关</a>
          </li>
          <li style="padding-left:362px;" id="s_4" class='s_li' onmouseover='mover(4);' onmouseout='mout(4);'>
            <a href="#">待开发</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">待开发</a>
          </li>
          <li style="padding-left:474px;" id="s_5" class='s_li' onmouseover='mover(5);' onmouseout='mout(5);'>
            <a href="#">站内公告</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">204公告</a>
          </li>
          <li style="padding-left:50%;" id="s_6" class='s_li' onmouseover='mover(6);' onmouseout='mout(6);'>
            <a href="#">战地日记</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">本站开发</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">程序猿</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">攻城狮</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">关于我们</a>
        </li>
          <li style="padding-left:70%;" id="s_7" class='s_li' onmouseover='mover(7);' onmouseout='mout(7);'>
            <a href="#">204主页</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">团队建设</a>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">项目进展</a>
        </li>
          </ul>
        </div>
      </div>
    </header>
{{end}}

{{define "blogBody"}}
    <div id="blogBody">
      <h2 align="center"> 开发中...</h2>
    </div>
{{end}}