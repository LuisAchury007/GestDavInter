<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormError.aspx.cs" Inherits="FormError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1, minimum-scale=1, width=device-width">
    <title>Error</title>
    <style>
        * {
            margin: 0;
            padding: 0;
        }

        html, code {
            font: 15px/22px arial,sans-serif;
        }

        html {
            background: #fff;
            color: #222;
            padding: 15px;
        }

        body {
            margin: 7% auto 0;
            max-width: 390px;
            min-height: 180px;
            padding: 30px 0 15px;
        }

        * > body {
            background: url(~/../Grafix/Advertencia.png) 100% no-repeat;
            padding-right: 100px;
            background-size: 20%;
        }

        p {
            margin: 11px 0 22px;
            overflow: hidden;
        }

        ins {
            color: #777;
            text-decoration: none;
        }

        a img {
            border: 0;
        }

        @media screen and (max-width:772px) {
            body {
                background: none;
                margin-top: 0;
                max-width: none;
                padding-right: 0;
            }
        }

        #logo {
            background: url(~/../Grafix/logo_CMYK1.png) no-repeat;
            margin-left: -5px;
            background-size: 100%;
        }

        #logo {
            display: inline-block;
            height: 64px;
            width: 160px;
        }
    </style>
</head>
<body>
    <a href="GCredGestor.aspx"><span id="logo" aria-label="Gestor"></span></a>
    <p>
        <ins>Ha ocurrido un problema.</ins>
    </p>
    <p>
        Se ha producido un inconveniente en la página web. Para retornar al sitio web por favor haga clic en el icono de gestor o <a href="GCredGestor.aspx"><ins>haga clic aquí</ins></a>
    </p>
</body>
</html>
