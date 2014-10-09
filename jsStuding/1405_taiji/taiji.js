window.onload = myDrawing;
var cirX = 303;
var cirY = 303;
var MainR = 150;
var RotateTimeOut = 10;
var fillColorB = 'rgba(0,0,0,1)';
var fillColorW = 'rgba(255,255,255,1)';
var strokeColorB = 'rgba(0,0,0,1)';
var strokeColorW = 'rgba(255,255,255,1)';
var r=1,g=1,b=1;
function drawCri(context) {

    context.beginPath();
    context.arc(0, 0, MainR + 2, 0, Math.PI * 2, false);
    context.closePath();
    context.strokeStyle = strokeColorB;
    context.stroke();

    context.beginPath();
    context.arc(0, -MainR / 2, MainR / 2, -Math.PI / 2, +Math.PI / 2, false);
    context.arc(0, MainR / 2, MainR / 2, -Math.PI / 2, +Math.PI / 2, true);
    context.arc(0, 0, MainR, Math.PI / 2, Math.PI + Math.PI / 2, true);
    context.closePath();
    context.fillStyle = fillColorB;
    context.fill();
    context.stroke();

    context.beginPath();
    context.arc(0, 0, MainR, -Math.PI / 2, Math.PI / 2, true);
    context.arc(0, MainR / 2, MainR / 2, Math.PI / 2, Math.PI * 3 / 2, false);
    context.arc(0, -MainR / 2, MainR / 2, Math.PI / 2, -Math.PI / 2, true);
    context.closePath();
    context.fillStyle = fillColorW;
    context.fill();
    context.stroke();

    context.beginPath();
    context.arc(0, MainR / 2, MainR / 12, 0, Math.PI * 2, false);
    context.closePath();
    context.fillStyle = fillColorW;
    context.fill();

    context.beginPath();
    context.arc(0, -MainR / 2, MainR / 12, 0, Math.PI * 2, false);
    context.closePath();
    context.fillStyle = fillColorB;
    context.fill();

    context.save();
    context.restore();
}

function myDrawing() {
    var drawing = document.getElementById("myDraw");
    if (drawing.getContext("2d")) {
        var context = drawing.getContext("2d");
        context.translate(cirX, cirY);
        drawCri(context);
    };
    setTimeout(rotateDraw, RotateTimeOut);
}
var add1=5,add2=5,add3=5;
function rotateDraw() {
		if(r<255&&r>0)
		{
				if(g<255&&g>0)
				{
						if(b<255&&b>0)
						{
								b+=add1;
						}
						else
						{
								add1*=-1;
								b+=add1;
								g+=add2;
								
						}	
				}
				else
				{
						add2*=-1;
						g+=add2;
						r+=add3;
						//alert(add1+''+add2+''+add4);
				}	
		}
		else
		{
				add3*=-1;
				r+=add3;
		}		
		fillColorB = 'rgba('+r+','+g+','+b+',1)';
		fillColorW =  'rgba('+(255-r)+','+(255-g)+','+(255-b)+',1)';
		strokeColorB =  'rgba('+r+','+g+','+b+',1)';
		strokeColorW = 'rgba('+(255-r)+','+(255-g)+','+(255-b)+',1)';
		var drawing = document.getElementById("myDraw");
		if (drawing.getContext("2d")) {
				var context = drawing.getContext("2d");
				context.translate(-cirX, -cirY);
				context.clearRect(0, 0, 600, 600);
				context.translate(cirX, cirY);
				context.rotate(Math.PI / 97); //开始旋转
				drawCri(context);
		};
		setTimeout(rotateDraw, RotateTimeOut);
}