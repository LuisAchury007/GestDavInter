var sw = 0;

function A(s)
{
var rcFile = new Array();
rcFile = s.split("/");
var imagen = rcFile[rcFile.length - 1];
var imgObj=document.getElementById('Image2');
if (sw == 0) {
parent.document.getElementById('frameset1').cols="5%,*";
imgObj.alt="Mostrar frame izquierdo";
sw = 1;
}
else if (sw == 1) {
parent.document.getElementById('frameset1').cols="24%,* ";
imgObj.alt="Ocultar frame izquierdo";
sw = 0;
}
}