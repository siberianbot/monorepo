# Rendering: Text Rendering #

**nb:** this text was written before.

## Purpose ##

This document describes information about text rendering in rengine, 
because this process is complicated enough.

## Main conception of text rendering in rengine ##

Let's begin from some introduction. 

In real world we have a dozen of alphabets: latin, greek, cyrillic, chinese, 
japanese and much more. Also we have a thousands of languages (this number
correlates from 2500 to 7000). The main problem of that is "how to represent any
character or glyph from any of this languages?" 

For this purpose was created Unicode. It contains almost all character from all 
languages. Cool, right? But there is another problem.

Actually, our games or apps can be translated to any language. And it will be great
if rengine have built-in support for all languages (that's why we use UTF 
everywhere). But problem is "how to render character from any language without
serious problems?" 

What I call "serious problems":
* High memory consumption - we can't store in all glyphs at the same time;
* Not related glyphs - some glyph may be unused;
* ...and other problems.

rengine utilizes next approach for storing all glyphs in texture atlas(es):
https://blackpawn.com/texts/lightmaps/default.html

## Links ##

* https://blackpawn.com/texts/lightmaps/default.html - algorithm of packing 
lightmaps (and anything else); 