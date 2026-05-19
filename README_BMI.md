# 🏋️ BMI Calculator

A simple and clean WinForms desktop application that calculates your Body Mass Index (BMI) and tells you what category you fall into.

---

## 🚀 Features

- Clean dark-themed interface
- Calculates BMI based on height (cm) and weight (kg)
- Displays the result with a color-coded category
- Provides a short health tip based on the result
- Input validation — no crashes on invalid values

---

## 🎨 BMI Categories

| BMI | Category | Color |
|-----|----------|-------|
| Below 18.5 | Underweight | 🔵 Blue |
| 18.5 – 24.9 | Normal weight | 🟢 Green |
| 25.0 – 29.9 | Overweight | 🟡 Yellow |
| 30.0+ | Obese | 🔴 Red |

---

## ⚙️ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) — required to build and run the app
- Windows OS (WinForms is Windows-only)

---

## ▶️ How to Run

**1. Clone the repository**
```bash
git clone https://github.com/your-username/bmi-calculator.git
cd bmi-calculator
```

**2. Create a new WinForms project**
```bash
dotnet new winforms -n BMICalculator
cd BMICalculator
```

**3. Replace `Program.cs` with the file from this repository**

**4. Run the application**
```bash
dotnet run
```

---

## 📋 Example Output

Enter your height and weight, then click **CALCULATE**:

```
Height: 175 cm
Weight: 70 kg

BMI: 22.9
Category: Normal weight ✅
"Great! Keep up your healthy habits."
```

---

## 🛠️ Technologies

- **Language:** C#
- **Framework:** .NET 8 / WinForms
- **IDE:** Visual Studio Code

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
