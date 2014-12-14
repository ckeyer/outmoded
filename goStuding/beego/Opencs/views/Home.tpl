<!DOCTYPE html>

  {{template "mainHead"}}
    <title>OPENCS--Home</title>
  </head>

  <body>
  	<header>
  	  <div id = "mainHeader1">
  	    <div id="menu">

  	      <div id = "menuLeft">
  	          <a class="m_login" href="#">
                <img id="logoImg" src="../static/img/opencs_logo24.png" />
              </a>
  	      </div>

  	      <div id = "menuRight">
  	        <strong>
  	          <a class="m_login" href="/login">登录</a>&nbsp;
  	        </strong>
  	          <img src="../static/img/line1.gif"/>
  	          <img src="../static/img/line1.gif"/>&nbsp;
  	          <a class="m_login" href="/sign">注册</a>
  	      </div>

  	      <div id = "menuCenter">
  	        <ul>
  	          <li class="m_line">
  	            <img src="../static/img/line1.gif" />
  	          </li>
  	          <li id="m_1" class='m_li_a' >
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
  	          <li id="m_3" class='m_li' onmouseover='mover(3);' onmouseout='mout(3);'>
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
	  	      <li style="padding-left:29px;" id="s_1" class='s_li_a'>
	  	        欢迎光临CJStudio开源小站，您是本站第
	  	        <font color="red">{{.ViewerCount}}</font>
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
	  	      <li style="padding-left:252px;" id="s_3" class='s_li' onmouseover='mover(3);' onmouseout='mout(3);'>
	  	        <a href="#">博客首页</a>
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
	  	      <li style="padding-left:360px;" id="s_6" class='s_li' onmouseover='mover(6);' onmouseout='mout(6);'>
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
	  	      <li style="padding-left:520px;" id="s_7" class='s_li' onmouseover='mover(7);' onmouseout='mout(7);'>
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


  	<div id="mainBody" >

  		<div id = "mainTitle">
  		  <div>
  		    <p>
  		      <h1>Main Title</h1>
  		    </p>
  		  </div>
  		</div>


  		<div id = "mainMessage">
  		  <div>
  		    <p>
  		      <h3>我是菜鸟，但我爱分享</h3>
  		    </p>
  		  </div>
  		</div>

  		<div id ="bodyRight">
  		  <p>This is a test html on Right.</p>
  		  <p>This is a test html on Right.</p>
  		  <p>This is a test html on Right.</p>
  		  <p>This is a test html on Right.</p>
  		  <p>This is a test html on Right.</p>
  		  <p>This is a test html on Right.</p>
  		  <p>This is a test html on Right.</p>
  		  <p>This is a test html on Right.</p>
  		  <p>This is a test html on Right.</p>
  		</div>

  		<div id ="bodyCenter">
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		  <p>This is a test html.</p>
  		</div>

  		<div id ="bodyLeft">
  		  <p>This is a test html on Left.</p>
  		  <p>This is a test html on Left.</p>
  		  <p>This is a test html on Left.</p>
  		  <p>This is a test html on Left.</p>
  		  <p>This is a test html on Left.</p>
  		  <p>This is a test html on Left.</p>
  		  <p>This is a test html on Left.</p>
  		  <p>This is a test html on Left.</p>
  		  <p>This is a test html on Left.</p>
  		</div>
  	</div>
{{template "mainDown"}}
