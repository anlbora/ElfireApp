# ElfireApp 🔥  
**Fire Compartment Analysis Tool based on Eurocode & International Standards**

---

## 📌 Overview

**ElfireApp** is a Windows Forms-based engineering software designed to model fire growth and temperature development in enclosures. It allows users to calculate **Eurocode-based parametric fire curves**, as well as compare them with **ISO 834**, **Hydrocarbon**, and **ASTM E119** standard time-temperature curves.

With its modular architecture and user-friendly graphical interface, ElfireApp enables professionals to simulate realistic fire scenarios based on geometric, material, and risk-related parameters.

---

## 🧮 Core Features

### 🔧 Compartment Designer
![Image](https://github.com/user-attachments/assets/9db1f2eb-f1c9-496c-acde-5c2e4b58942f)

- Define **geometry**: length, width, height
- Calculate **enclosure**, **wall**, **ceiling**, and **floor areas**
![Image](https://github.com/user-attachments/assets/aa332273-8654-4389-8b14-3f0627aa8f35)

- Add openings manually or calculate via **opening factor**
![Image](https://github.com/user-attachments/assets/ef4fa090-c1f9-4a8b-b2b3-2bd491c7a8fe)

### 🧱 Material Properties
- Select or define new materials for **walls**, **floor**, and **ceiling**
- Automatically computes **thermal inertia** of the compartment
![Image](https://github.com/user-attachments/assets/f7655a48-fd08-47a9-ba78-6ddb47929b08)
![Image](https://github.com/user-attachments/assets/966bda7f-107a-4eeb-854d-bae6d17279b1)
![Image](https://github.com/user-attachments/assets/4816f92c-61a8-4a32-a286-f80e5fb0152a)

### 🔥 Design Fire Parameters
- Import fire load & ROFI data (Occupancy / Floor Area)
- Apply **risk factors** based on real occupancy types and area categories
- Customize **combustion factor**, **fire duration**, and **suppression coefficient**
![Image](https://github.com/user-attachments/assets/368d8cfb-181e-453d-9b45-dad35ac81e2b)
![Image](https://github.com/user-attachments/assets/7a9c365e-a310-40e1-a10f-f354b0f94085)

### 📈 Curve Generation
- Calculate temperature-time data for:
  - **Ventilation-Controlled Fires**
  - **Fuel-Controlled Fires**
- Determine max temperature, duration, and other critical fire parameters
![Image](https://github.com/user-attachments/assets/ad2f251b-0ba7-47a9-a0ea-e3b673316db3)
![Image](https://github.com/user-attachments/assets/f97302ad-f160-4401-8d2f-d3eb2ff92f73)
![Image](https://github.com/user-attachments/assets/8476a93d-53d9-43d5-834b-51695b6bb4fe)

### 📊 Visualization
- Dynamic plotting of fire curves (with tooltips, phase filling, labels)
- Comparison module for:
  - ISO 834  
  - Hydrocarbon Fire Curve  
  - ASTM E119  
  - User-calculated Eurocode curves
![Image](https://github.com/user-attachments/assets/8476a93d-53d9-43d5-834b-51695b6bb4fe)
![Image](https://github.com/user-attachments/assets/763dd41c-0fc1-4aeb-9647-8b25be2609c9)

### 💾 Export Options
- Export fire data to `.csv`, `.txt`, `.html`, or `.elf` (custom save file)
- Save full report packages including screenshots and comparison charts

---

## 🗂️ Project Structure
```
ElfireApp/
│
├── Forms/ # All UI Forms (MainPage, CompareForms, etc.)
│ ├── EurocodeCurve.cs # Main user control for Eurocode fire curve
│ ├── CompareCurvesForm.cs # Form for ISO/ASTM/Hydrocarbon comparison
│ ├── CompareEurocodeCurvesForm.cs # Eurocode-to-Eurocode comparison
│ └── [other form modules...]
│
├── Curves/ # Calculation logic for each standard
│ ├── ISO834_Curve.cs
│ ├── HydroCarbonCurve.cs
│ ├── ASTM_E119.cs
│ └── Eurocode.cs # Core Eurocode calculation logic
│
├── Data/ # Data structures and ROFI inputs
│ ├── MaterialData.cs
│ ├── ROFI_OccupancyData.cs
│ ├── ROFI_FloorAreaData.cs
│ └── DesignFireLoadData.cs
│
├── Resources/ # Icons, images, settings
├── Program.cs # Entry point
└── README.md
```

---

## 💡 Technical Highlights

- **Eurocode Fire Curve** classification:  
  🔹 _Ventilation-Controlled_ vs. 🔸 _Fuel-Controlled_  
  is determined dynamically via `t_max` comparison with limiting time.

- Curve behavior includes:
  - Heating and cooling phases with time-dependent decay
  - Accurate maximum temperature calculation (`t_max_2`, `t_max_3`, etc.)

- Tooltip and GraphMouseMove for real-time point inspection

---

## 🔍 Future Enhancements

- [ ] Integration with **LiveCharts** or **OxyPlot** for advanced graphing  
- [ ] SQLite-based material & ROFI persistence  
- [ ] Multi-language support  
- [ ] Advanced export templates (PDF)

---


