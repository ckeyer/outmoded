{{define "mainHead"}}
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

    <link href="../static/css/mainHeader.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../static/js/main.js"></script> 
{{end}}



{{define "mainDown"}}
  <div id ="mainDown">
    <div style="width:550px;margin:20px auto;">
    <p>网站版本：<strong>v1.0.2</strong></p> 
    <p>版权所有：<strong><a href="/lab204">lab204</a></strong> </p>
    <p>联系我们 <strong>
      <a href="/message">(给我们留言)</a>
      </strong>
      <br>
      <strong>邮箱:</strong><a href="./">wangcj1214@gmail.com</a> 
              <img src="../static/img/line1.gif"/>
      <strong>QQ:</strong> <a href="./">372896852</a>
    <p><strong>注</strong>：此网站仅供学习交流，不以任何方式参与商业运作。</p>
    </div>
  </div>
  </body>
</html>
{{end}}