# ElfireApp 🔥  
**Fire Compartment Analysis Tool based on Eurocode & International Standards**

---

## 📌 Overview

**ElfireApp** is a Windows Forms-based engineering software designed to model fire growth and temperature development in enclosures. It allows users to calculate **Eurocode-based parametric fire curves**, as well as compare them with **ISO 834**, **Hydrocarbon**, and **ASTM E119** standard time-temperature curves.

With its modular architecture and user-friendly graphical interface, ElfireApp enables professionals to simulate realistic fire scenarios based on geometric, material, and risk-related parameters.

---

## 🧮 Core Features

### 🔧 Compartment Designer
- Define **geometry**: length, width, height
- Calculate **enclosure**, **wall**, **ceiling**, and **floor areas**
- Add openings manually or calculate via **opening factor**

### 🧱 Material Properties
- Select or define new materials for **walls**, **floor**, and **ceiling**
- Automatically computes **thermal inertia** of the compartment

### 🔥 Design Fire Parameters
- Import fire load & ROFI data (Occupancy / Floor Area)
- Apply **risk factors** based on real occupancy types and area categories
- Customize **combustion factor**, **fire duration**, and **suppression coefficient**

### 📈 Curve Generation
- Calculate temperature-time data for:
  - **Ventilation-Controlled Fires**
  - **Fuel-Controlled Fires**
- Determine max temperature, duration, and other critical fire parameters

### 📊 Visualization
- Dynamic plotting of fire curves (with tooltips, phase filling, labels)
- Comparison module for:
  - ISO 834  
  - Hydrocarbon Fire Curve  
  - ASTM E119  
  - User-calculated Eurocode curves

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

## 📸 Sample Screens

| Curve Comparison | Eurocode Comparison | Eurocode Curve UI |
|------------------|---------------------|-------------------|
| ![Compare Curves](screenshots/compare_curves.png) | ![Eurocode Comparison](screenshots/eurocode_comparison.png) | ![Curve UI](screenshots/eurocode_curve.png) |

---

## 🔍 Future Enhancements

- [ ] Integration with **LiveCharts** or **OxyPlot** for advanced graphing  
- [ ] SQLite-based material & ROFI persistence  
- [ ] Multi-language support  
- [ ] Advanced export templates (PDF)

---

## 👨‍💻 Author

Developed by **Anıl Bora**  
Doctoral Researcher in Structural Fire Engineering  
İzmir Institute of Technology

---

## 📜 License

This project is licensed for academic and educational use only. Contact the author for commercial or research applications.


