# OldMobilePhonePad

This project implements a solution for simulating the behavior of an old mobile phone keypad. The keypad maps numeric keys to alphabetical letters, allowing users to type text by pressing buttons multiple times.

## Problem Statement

Old mobile phone keypads allow users to type letters by pressing numeric keys multiple times. For example:
- Pressing `2` once produces `A`
- Pressing `2` twice produces `B`
- Pressing `2` three times produces `C`

Each button has a unique set of letters assigned to it. To type multiple characters from the same key, users need to pause or use a delimiter. Additionally:
- `*` acts as a backspace key.
- `#` acts as a "send" key, marking the end of input.

The goal is to create a method, `OldPhonePad`, that takes an input string representing keypresses and outputs the corresponding text.

---

## Implementation

The project includes the following:
1. A mapping of numeric keys to their respective letters.
2. Logic to handle repeated keypresses for cycling through letters.
3. Special handling for backspace (`*`) and end (`#`) keys.

### **Keypad Layout**

| Key | Characters     |
|-----|----------------|
| 1   | (None)         |
| 2   | A, B, C        |
| 3   | D, E, F        |
| 4   | G, H, I        |
| 5   | J, K, L        |
| 6   | M, N, O        |
| 7   | P, Q, R, S     |
| 8   | T, U, V        |
| 9   | W, X, Y, Z     |
| 0   | (Space)        |
| *   | Backspace      |
| #   | Send (End)     |

---

## Method Details

### **Signature**

```csharp
public static string OldPhonePad(string input)
