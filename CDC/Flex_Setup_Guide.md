# Flex Setup Guide (Windows)

This guide explains how to install and set up **Flex** on Windows with MinGW GCC.

## 1. Install Flex

1. Go to: [Flex for Windows (GnuWin32)](https://gnuwin32.sourceforge.net/packages/flex.htm)
2. Download **Complete package, except sources → Setup**
3. Install the file named **`flex-2.5.4a-1.exe`**
4. After installation, go to the installed folder and copy the **bin** folder path (example: `C:\Program Files (x86)\GnuWin32\bin`)

## 2. Add Flex to Environment Variables

1. Open **Environment Variables** → edit **Path**
2. Add the copied **bin** path
3. Open CMD and check installation:
   ```bash
   flex --version
   ```

## 3. Install MinGW GCC

1. Download and install MinGW GCC
2. Locate the bin folder path (example: `C:\MinGW\bin`)
3. Add this path to Environment Variables (same as above)
4. Verify installation:
   ```bash
   gcc --version
   ```

## 4. Run a Flex Program

1. Create a folder (example: `C:\flex-demos`)
2. Inside it, create a file (example: `sum.l`)
3. Open CMD in the same folder and run:
   ```bash
   flex sum.l
   gcc lex.yy.c
   ```
   or (to name the output file):
   ```bash
   gcc lex.yy.c -o sum.exe
   ```

# Quick Start (Cheat Sheet)

## Install
- Install Flex (flex-2.5.4a-1.exe) → add ...\GnuWin32\bin to PATH
- Install MinGW GCC → add ...\MinGW\bin to PATH

## Verify
```bash
flex --version
gcc --version
```

## Run
```bash
flex file.l
gcc lex.yy.c -o file.exe
file.exe
```
