#!/bin/bash
shopt -s extglob
rm -r !(Release)
cp -r Release/. .
rm -r Release