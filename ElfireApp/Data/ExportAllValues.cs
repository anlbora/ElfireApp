using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElfireApp.Curves;
using ElfireApp.Properties;

namespace ElfireApp.Data
{
    public class ExportAllValues
    {
        public string CurveTitle { get; set; }

        public string CurveName { get; set; }
        public string CurveCode { get; set; }
        public string FireType { get; set; }
        public double MaximumTemperature { get; set; }
        public double MaximumTemperatureTime { get; set; }

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double FloorArea { get; set; }
        public double CeilingArea { get; set; }
        public double WallsArea { get; set; }
        public double EnclosureArea { get; set; }

        public double OpeningArea { get; set; }
        public double AverageHeight { get; set; }
        public double OpeningFactor { get; set; }
        public double OpeningFactor_Lim { get; set; }

        public Material WallMaterial { get; set; }
        public Material FloorMaterial { get; set; }
        public Material CeilingMaterial { get; set; }

        public double WallThermalInertia { get; set; }
        public double FloorThermalInertia { get; set; }
        public double CeilingThermalInertia { get; set; }
        public double CompartmentThermalInertia { get; set; }

        public string OccupancyType { get; set; }
        public FireGrowthRate FireGrowthRate { get; set; }
        public double DesignValue_q_fk { get; set; }
        public double FireDesignLoad_q_fd { get; set; }
        public double TotalDesignFireLoad_q_td { get; set; }
        public double ROFI_Occupancy_gama_1 { get; set; }
        public double ROFI_FloorArea_gama_2 { get; set; }

        public double LimitingTime_t_lim { get; set; }
        public double FireDuration { get; set; }
        public double TimeFactor { get; set; }
        public double TimeFactor_Lim { get; set; }
        public double t_max { get; set; }
        public double t_max_2 { get; set; }
        public double t_max_3 { get; set; }
        public double t_max_4 { get; set; }

        public double CombustionFactor_m { get; set; }
        public double ActiveSuppressionCoefficient_gama_n { get; set; }

        public List<double> Times { get; set; }
        public List<double> Temperatures { get; set; }


        public string Ventilation_HTML { get; set; }
        public string Fuel_HTML { get; set; }

        public string Ventilation_HTML_Report { get; set; }
        public string Fuel_HTML_Report { get; set; }


        public ExportAllValues()
        {


        Ventilation_HTML = @"<!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Report - {ReportTitle}</title>
                    <!-- Include Chart.js from a CDN -->
                    <script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>
                    <style>
                        * {
                            margin: 0;
                            padding: 0;
                            box-sizing: border-box;
                        }

                        body {
                            font-size: 1rem;
                            font-family: 'Arial', sans-serif;
                            background-color: #f0f4f8;
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            min-height: 100vh;
                            margin: 0;
                            padding: 0;
                        }

                        .report-container {
                            background-color: #ffffff;
                            padding: 30px;
                            border-radius: 10px;
                            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                            max-width: 800px;
                            width: 75%;
                            margin: 20px;
                        }

                        .header {
                            display: flex;
                            justify-content: space-between;
                            align-items: center;
                            margin-bottom: 20px;
                            border-bottom: 2px solid #007bff;
                            padding-bottom: 10px;
                        }

                        .header h1 {
                            margin: 0;
                            font-size: 1.5rem;
                            color: #333;
                        }

                        .header p {
                            margin: 0;
                            color: #666;
                            font-size: 0.9rem;
                        }

                        .section {
                            margin-bottom: 30px;
                        }

                        .section-title {
                            font-size: 20px;
                            color: #555;
                            margin-bottom: 15px;
                            border-bottom: 2px solid #ddd;
                            padding-bottom: 8px;
                            text-align: left;
                        }

                        .property-table {
                            width: 100%;
                            border-collapse: separate;
                            margin-top: 15px;
                        }

                        .property-table th, .property-table td {
                            padding: 12px;
                            text-align: left; 
                            border-bottom: 1px solid #ddd;
                        }

                        .property-table th {
                            background-color: #f2f2f2;
                            color: #333;
                            width: 60%;
                        }

                        .property-table td {
                            background-color: #fafafa;
                        }

                        .interactive {
                            margin-top: 20px;
                            text-align: center;
                        }

                        button {
                            padding: 12px 25px;
                            font-size: 16px;
                            color: white;
                            background-color: #007bff;
                            border: none;
                            border-radius: 5px;
                            cursor: pointer;
                            transition: background-color 0.3s ease;
                        }

                        button:hover {
                            background-color: #0056b3;
                        }

                        /* Media Queries for Responsiveness */
                        @media (max-width: 768px) {
                            .report-container {
                                width: 90%;
                                padding: 15px;
                            }

                            .header h1 {
                                font-size: 1rem;
                            }

                            .section-title {
                                font-size: 18px;
                            }

                            .property-table th, .property-table td {
                                padding: 10px;
                                font-size: 0.9rem;
                            }

                            .header p {
                                font-size: 0.7rem;
                                margin-top: 3px;
                            }
                        }

                        @media (max-width: 480px) {
                            .report-container {
                                width: 95%;
                                padding: 10px;
                            }

                            .header {
                                flex-direction: column;
                                align-items: flex-start;
                            }

                            .header h1 {
                                font-size: 0.8rem;
                            }

                            button {
                                width: 100%;
                                padding: 10px 0;
                            }
                        }

                        /* Style to properly contain the canvas element */
                        #temperatureGraph {
                            max-height: 400px;
                            width: 100%;
                        }
                    </style>
                </head>
                <body>
                    <div class=""report-container"">
                        <div class=""header"">
                            <h1>{ReportTitle}</h1>
                            <p>{ReportDate}</p>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Curve Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Curve Name</th>
                                    <td>{CurveName}</td>
                                </tr>
                                <tr>
                                    <th>Curve Code</th>
                                    <td>{CurveCode}</td>
                                </tr>
                                <tr>
                                    <th>Fire Type</th>
                                    <td>{FireType}</td>
                                </tr>
                                <tr>
                                    <th>Maximum Temperature (°C)</th>
                                    <td>{MaxTemperature}</td>
                                </tr>
                                <tr>
                                    <th>Maximum Temperature Time (minutes)</th>
                                    <td>{MaxTemperatureTime}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Compartment Dimensions</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Length (m)</th>
                                    <td>{Length}</td>
                                </tr>
                                <tr>
                                    <th>Width (m)</th>
                                    <td>{Width}</td>
                                </tr>
                                <tr>
                                    <th>Height (m)</th>
                                    <td>{Height}</td>
                                </tr>
                                <tr>
                                    <th>Floor Area (m²)</th>
                                    <td>{FloorArea}</td>
                                </tr>
                                <tr>
                                    <th>Ceiling Area (m²)</th>
                                    <td>{CeilingArea}</td>
                                </tr>
                                <tr>
                                    <th>Walls Area (m²)</th>
                                    <td>{WallsArea}</td>
                                </tr>
                                <tr>
                                    <th>Enclosure Area (m²)</th>
                                    <td>{EnclosureArea}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Opening Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Opening Area (m²)</th>
                                    <td>{OpeningArea}</td>
                                </tr>
                                <tr>
                                    <th>Average Height (m)</th>
                                    <td>{AverageHeight}</td>
                                </tr>
                                <tr>
                                    <th>Opening Factor (m½)</th>
                                    <td>{OpeningFactor}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Walls Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{wallName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{wallDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{wallSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{wallThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Floor Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{floorName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{floorDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{floorSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{floorThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Ceiling Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{ceilingName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{ceilingDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{ceilingSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{ceilingThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Thermal Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Wall Thermal Inertia (J/(m²·K))</th>
                                    <td>{WallThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Floor Thermal Inertia (J/(m²·K))</th>
                                    <td>{FloorThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Ceiling Thermal Inertia (J/(m²·K))</th>
                                    <td>{CeilingThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Compartment Thermal Inertia (J/(m²·K))</th>
                                    <td>{CompartmentThermalInertia}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Design Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Occupancy Type</th>
                                    <td>{OccupancyType}</td>
                                </tr>
                                <tr>
                                    <th>Fire Growth Rate</th>
                                    <td>{FireGrowthRate}</td>
                                </tr>
                                <tr>
                                    <th>Fire Load Density (q_fk) MJ·m⁻²</th>
                                    <td>{FireLoadDensity}</td>
                                </tr>
                                <tr>
                                    <th>Design Fire Load Density (q_fd) MJ·m⁻²</th>
                                    <td>{DesignFireLoadDensity}</td>
                                </tr>
                                <tr>
                                    <th>Total Design Fire Load (q_td) MJ·m⁻²</th>
                                    <td>{TotalDesignFireLoad}</td>
                                </tr>
                                <tr>
                                    <th>ROFI - Occupancy (gama_1)</th>
                                    <td>{ROFI_Occupancy}</td>
                                </tr>
                                <tr>
                                    <th>ROFI - Floor Area (gama_2)</th>
                                    <td>{ROFI_FloorArea}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Time Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Limiting Time (hour)</th>
                                    <td>{LimitingTime}</td>
                                </tr>
                                <tr>
                                    <th>Fire Duration (minutes)</th>
                                    <td>{FireDuration}</td>
                                </tr>
                                <tr>
                                    <th>Time Factor</th>
                                    <td>{TimeFactor}</td>
                                </tr>
                                <tr>
                                    <th>t_max</th>
                                    <td>{t_max}</td>
                                </tr>
                                <tr>
                                    <th>t_max_2</th>
                                    <td>{t_max_2}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Other Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Combustion Factor</th>
                                    <td>{CombustionFactor}</td>
                                </tr>
                                <tr>
                                    <th>Active Fire Coefficient</th>
                                    <td>{ActiveFireCoefficient}</td>
                                </tr>
                            </table>
                        </div>

                        <!-- Interactive Graph Section -->
                        <div class=""section"">
                            <div class=""section-title"">Temperature vs Time Graph</div>
                            <canvas id=""temperatureGraph""></canvas>
                        </div>
                    </div>

                    <script>
                        var ctx = document.getElementById('temperatureGraph').getContext('2d');
                        var temperatureGraph;

                        function createGraph(labels, data) {
                            if (temperatureGraph) {
                                temperatureGraph.destroy();
                            }
    
                            temperatureGraph = new Chart(ctx, {
                                type: 'line',
                                data: {
                                    labels: labels,
                                    datasets: [{
                                        label: 'Temperature (°C)',
                                        data: data,
                                        borderColor: 'rgba(75, 192, 192, 1)',
                                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                        borderWidth: 2,
                                        pointRadius: 1,
                                        pointHoverRadius: 2,
                                    }]
                                },
                                options: {
                                    responsive: true,
                                    maintainAspectRatio: true,
                                    scales: {
                                        x: {
                                            title: {
                                                display: true,
                                                text: 'Time (minutes)'
                                            }
                                        },
                                        y: {
                                            title: {
                                                display: true,
                                                text: 'Temperature (°C)'
                                            },
                                            beginAtZero: true,
                                        }
                                    }
                                }
                            });
                        }

                        // Simulate CSV data processing
                        function simulateCsvData() {
                            const csvData = 
                                {csv_data}
                            ; 
                            processData(csvData);
                        }

                        function processData(csvData) {
                            var lines = csvData.trim().split('\n');
                            var labels = [];
                            var data = [];

                            for (var i = 0; i < lines.length; i += 5) {
                                var line = lines[i].trim();
                                if (line) {
                                    var parts = line.split(' ');
                                    var timeInSeconds = parseInt(parts[0]);
                                    var temperature = parseFloat(parts[1]);

                                    var timeInMinutes = (timeInSeconds / 60).toFixed(2);
                                    labels.push(timeInMinutes);
                                    data.push(temperature);
                                }
                            }

                            createGraph(labels, data);
                        }

                        simulateCsvData();

                    </script>
                </body>
            </html>

        ";
        Ventilation_HTML_Report = @"<!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Report - {ReportTitle}</title>
                    <!-- Include Chart.js from a CDN -->
                    <script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>
                    <style>
                        * {
                            margin: 0;
                            padding: 0;
                            box-sizing: border-box;
                        }

                        body {
                            font-size: 1rem;
                            font-family: 'Arial', sans-serif;
                            background-color: #f0f4f8;
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            min-height: 100vh;
                            margin: 0;
                            padding: 0;
                        }

                        .report-container {
                            background-color: #ffffff;
                            padding: 30px;
                            border-radius: 10px;
                            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                            max-width: 800px;
                            width: 75%;
                            margin: 20px;
                        }

                        .header {
                            display: flex;
                            justify-content: space-between;
                            align-items: center;
                            margin-bottom: 20px;
                            border-bottom: 2px solid #007bff;
                            padding-bottom: 10px;
                        }

                        .header h1 {
                            margin: 0;
                            font-size: 1.5rem;
                            color: #333;
                        }

                        .header p {
                            margin: 0;
                            color: #666;
                            font-size: 0.9rem;
                        }

                        .section {
                            margin-bottom: 30px;
                        }

                        .section-title {
                            font-size: 20px;
                            color: #555;
                            margin-bottom: 15px;
                            border-bottom: 2px solid #ddd;
                            padding-bottom: 8px;
                            text-align: left;
                        }

                        .property-table {
                            width: 100%;
                            border-collapse: separate;
                            margin-top: 15px;
                        }

                        .property-table th, .property-table td {
                            padding: 12px;
                            text-align: left; 
                            border-bottom: 1px solid #ddd;
                        }

                        .property-table th {
                            background-color: #f2f2f2;
                            color: #333;
                            width: 60%;
                        }

                        .property-table td {
                            background-color: #fafafa;
                        }

                        .interactive {
                            margin-top: 20px;
                            text-align: center;
                        }

                        button {
                            padding: 12px 25px;
                            font-size: 16px;
                            color: white;
                            background-color: #007bff;
                            border: none;
                            border-radius: 5px;
                            cursor: pointer;
                            transition: background-color 0.3s ease;
                        }

                        button:hover {
                            background-color: #0056b3;
                        }

                        /* Media Queries for Responsiveness */
                        @media (max-width: 768px) {
                            .report-container {
                                width: 90%;
                                padding: 15px;
                            }

                            .header h1 {
                                font-size: 1rem;
                            }

                            .section-title {
                                font-size: 18px;
                            }

                            .property-table th, .property-table td {
                                padding: 10px;
                                font-size: 0.9rem;
                            }

                            .header p {
                                font-size: 0.7rem;
                                margin-top: 3px;
                            }
                        }

                        @media (max-width: 480px) {
                            .report-container {
                                width: 95%;
                                padding: 10px;
                            }

                            .header {
                                flex-direction: column;
                                align-items: flex-start;
                            }

                            .header h1 {
                                font-size: 0.8rem;
                            }

                            button {
                                width: 100%;
                                padding: 10px 0;
                            }
                        }

                        /* Style to properly contain the canvas element */
                        #temperatureGraph {
                            max-height: 400px;
                            width: 100%;
                        }
                    </style>
                </head>
                <body>
                    <div class=""report-container"">
                        <div class=""header"">
                            <h1>{ReportTitle}</h1>
                            <p>{ReportDate}</p>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Curve Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Curve Name</th>
                                    <td>{CurveName}</td>
                                </tr>
                                <tr>
                                    <th>Curve Code</th>
                                    <td>{CurveCode}</td>
                                </tr>
                                <tr>
                                    <th>Fire Type</th>
                                    <td>{FireType}</td>
                                </tr>
                                <tr>
                                    <th>Maximum Temperature (°C)</th>
                                    <td>{MaxTemperature}</td>
                                </tr>
                                <tr>
                                    <th>Maximum Temperature Time (minutes)</th>
                                    <td>{MaxTemperatureTime}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Compartment Dimensions</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Length (m)</th>
                                    <td>{Length}</td>
                                </tr>
                                <tr>
                                    <th>Width (m)</th>
                                    <td>{Width}</td>
                                </tr>
                                <tr>
                                    <th>Height (m)</th>
                                    <td>{Height}</td>
                                </tr>
                                <tr>
                                    <th>Floor Area (m²)</th>
                                    <td>{FloorArea}</td>
                                </tr>
                                <tr>
                                    <th>Ceiling Area (m²)</th>
                                    <td>{CeilingArea}</td>
                                </tr>
                                <tr>
                                    <th>Walls Area (m²)</th>
                                    <td>{WallsArea}</td>
                                </tr>
                                <tr>
                                    <th>Enclosure Area (m²)</th>
                                    <td>{EnclosureArea}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Opening Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Opening Area (m²)</th>
                                    <td>{OpeningArea}</td>
                                </tr>
                                <tr>
                                    <th>Average Height (m)</th>
                                    <td>{AverageHeight}</td>
                                </tr>
                                <tr>
                                    <th>Opening Factor (m½)</th>
                                    <td>{OpeningFactor}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Walls Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{wallName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{wallDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{wallSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{wallThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Floor Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{floorName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{floorDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{floorSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{floorThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Ceiling Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{ceilingName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{ceilingDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{ceilingSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{ceilingThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Thermal Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Wall Thermal Inertia (J/(m²·K))</th>
                                    <td>{WallThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Floor Thermal Inertia (J/(m²·K))</th>
                                    <td>{FloorThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Ceiling Thermal Inertia (J/(m²·K))</th>
                                    <td>{CeilingThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Compartment Thermal Inertia (J/(m²·K))</th>
                                    <td>{CompartmentThermalInertia}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Design Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Occupancy Type</th>
                                    <td>{OccupancyType}</td>
                                </tr>
                                <tr>
                                    <th>Fire Growth Rate</th>
                                    <td>{FireGrowthRate}</td>
                                </tr>
                                <tr>
                                    <th>Fire Load Density (q_fk) MJ·m⁻²</th>
                                    <td>{FireLoadDensity}</td>
                                </tr>
                                <tr>
                                    <th>Design Fire Load Density (q_fd) MJ·m⁻²</th>
                                    <td>{DesignFireLoadDensity}</td>
                                </tr>
                                <tr>
                                    <th>Total Design Fire Load (q_td) MJ·m⁻²</th>
                                    <td>{TotalDesignFireLoad}</td>
                                </tr>
                                <tr>
                                    <th>ROFI - Occupancy (gama_1)</th>
                                    <td>{ROFI_Occupancy}</td>
                                </tr>
                                <tr>
                                    <th>ROFI - Floor Area (gama_2)</th>
                                    <td>{ROFI_FloorArea}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Time Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Limiting Time (hour)</th>
                                    <td>{LimitingTime}</td>
                                </tr>
                                <tr>
                                    <th>Fire Duration (minutes)</th>
                                    <td>{FireDuration}</td>
                                </tr>
                                <tr>
                                    <th>Time Factor</th>
                                    <td>{TimeFactor}</td>
                                </tr>
                                <tr>
                                    <th>t_max</th>
                                    <td>{t_max}</td>
                                </tr>
                                <tr>
                                    <th>t_max_2</th>
                                    <td>{t_max_2}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Other Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Combustion Factor</th>
                                    <td>{CombustionFactor}</td>
                                </tr>
                                <tr>
                                    <th>Active Fire Coefficient</th>
                                    <td>{ActiveFireCoefficient}</td>
                                </tr>
                            </table>
                        </div>

                        <!-- Interactive Graph Section -->
                        <div class=""section"">
                            <div class=""section-title"">Temperature vs Time Graph</div>
                            <canvas id=""temperatureGraph""></canvas>
                        </div>
                    </div>

                <script>
                        var ctx = document.getElementById('temperatureGraph').getContext('2d');
                        var temperatureGraph;

                        function createGraph(labels, data) {
                            if (temperatureGraph) {
                                temperatureGraph.destroy();
                            }

                            temperatureGraph = new Chart(ctx, {
                                type: 'line',
                                data: {
                                    labels: labels,
                                    datasets: [{
                                        label: 'Temperature (°C)',
                                        data: data,
                                        borderColor: 'rgba(75, 192, 192, 1)',
                                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                        borderWidth: 2,
                                        pointRadius: 1,
                                        pointHoverRadius: 2,
                                    }]
                                },
                                options: {
                                    responsive: true,
                                    maintainAspectRatio: true,
                                    scales: {
                                        x: {
                                            title: {
                                                display: true,
                                                text: 'Time (minutes)'
                                            }
                                        },
                                        y: {
                                            title: {
                                                display: true,
                                                text: 'Temperature (°C)'
                                            },
                                            beginAtZero: true,
                                        }
                                    }
                                }
                            });
                        }

                        // Use the Times and Temperatures directly if this is a ""_Report""
                        var times = {js_times};
                        var temperatures = {js_temperatures};

                        createGraph(times, temperatures);
                    </script>

                </body>
            </html>

        ";

            Fuel_HTML = @"<!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Report - {ReportTitle}</title>
                    <!-- Include Chart.js from a CDN -->
                    <script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>
                    <style>
                        * {
                            margin: 0;
                            padding: 0;
                            box-sizing: border-box;
                        }

                        body {
                            font-size: 1rem;
                            font-family: 'Arial', sans-serif;
                            background-color: #f0f4f8;
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            min-height: 100vh;
                            margin: 0;
                            padding: 0;
                        }

                        .report-container {
                            background-color: #ffffff;
                            padding: 30px;
                            border-radius: 10px;
                            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                            max-width: 800px;
                            width: 75%;
                            margin: 20px;
                        }

                        .header {
                            display: flex;
                            justify-content: space-between;
                            align-items: center;
                            margin-bottom: 20px;
                            border-bottom: 2px solid #007bff;
                            padding-bottom: 10px;
                        }

                        .header h1 {
                            margin: 0;
                            font-size: 1.5rem;
                            color: #333;
                        }

                        .header p {
                            margin: 0;
                            color: #666;
                            font-size: 0.9rem;
                        }

                        .section {
                            margin-bottom: 30px;
                        }

                        .section-title {
                            font-size: 20px;
                            color: #555;
                            margin-bottom: 15px;
                            border-bottom: 2px solid #ddd;
                            padding-bottom: 8px;
                            text-align: left;
                        }

                        .property-table {
                            width: 100%;
                            border-collapse: separate;
                            margin-top: 15px;
                        }

                        .property-table th, .property-table td {
                            padding: 12px;
                            text-align: left; 
                            border-bottom: 1px solid #ddd;
                        }

                        .property-table th {
                            background-color: #f2f2f2;
                            color: #333;
                            width: 60%;
                        }

                        .property-table td {
                            background-color: #fafafa;
                        }

                        .interactive {
                            margin-top: 20px;
                            text-align: center;
                        }

                        button {
                            padding: 12px 25px;
                            font-size: 16px;
                            color: white;
                            background-color: #007bff;
                            border: none;
                            border-radius: 5px;
                            cursor: pointer;
                            transition: background-color 0.3s ease;
                        }

                        button:hover {
                            background-color: #0056b3;
                        }

                        /* Media Queries for Responsiveness */
                        @media (max-width: 768px) {
                            .report-container {
                                width: 90%;
                                padding: 15px;
                            }

                            .header h1 {
                                font-size: 1rem;
                            }

                            .section-title {
                                font-size: 18px;
                            }

                            .property-table th, .property-table td {
                                padding: 10px;
                                font-size: 0.9rem;
                            }

                            .header p {
                                font-size: 0.7rem;
                                margin-top: 3px;
                            }
                        }

                        @media (max-width: 480px) {
                            .report-container {
                                width: 95%;
                                padding: 10px;
                            }

                            .header {
                                flex-direction: column;
                                align-items: flex-start;
                            }

                            .header h1 {
                                font-size: 0.8rem;
                            }

                            button {
                                width: 100%;
                                padding: 10px 0;
                            }
                        }

                        /* Style to properly contain the canvas element */
                        #temperatureGraph {
                            max-height: 400px;
                            width: 100%;
                        }
                    </style>
                </head>
                <body>
                    <div class=""report-container"">
                        <div class=""header"">
                            <h1>{ReportTitle}</h1>
                            <p>{ReportDate}</p>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Curve Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Curve Name</th>
                                    <td>{CurveName}</td>
                                </tr>
                                <tr>
                                    <th>Curve Code</th>
                                    <td>{CurveCode}</td>
                                </tr>
                                <tr>
                                    <th>Fire Type</th>
                                    <td>{FireType}</td>
                                </tr>
                                <tr>
                                    <th>Maximum Temperature (°C)</th>
                                    <td>{MaxTemperature}</td>
                                </tr>
                                <tr>
                                    <th>Maximum Temperature Time (minutes)</th>
                                    <td>{MaxTemperatureTime}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Compartment Dimensions</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Length (m)</th>
                                    <td>{Length}</td>
                                </tr>
                                <tr>
                                    <th>Width (m)</th>
                                    <td>{Width}</td>
                                </tr>
                                <tr>
                                    <th>Height (m)</th>
                                    <td>{Height}</td>
                                </tr>
                                <tr>
                                    <th>Floor Area (m²)</th>
                                    <td>{FloorArea}</td>
                                </tr>
                                <tr>
                                    <th>Ceiling Area (m²)</th>
                                    <td>{CeilingArea}</td>
                                </tr>
                                <tr>
                                    <th>Walls Area (m²)</th>
                                    <td>{WallsArea}</td>
                                </tr>
                                <tr>
                                    <th>Enclosure Area (m²)</th>
                                    <td>{EnclosureArea}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Opening Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Opening Area (m²)</th>
                                    <td>{OpeningArea}</td>
                                </tr>
                                <tr>
                                    <th>Average Height (m)</th>
                                    <td>{AverageHeight}</td>
                                </tr>
                                <tr>
                                    <th>Opening Factor (m½)</th>
                                    <td>{OpeningFactor}</td>
                                </tr>
                                <tr>
                                    <th>Opening Factor Lim (m½)</th>
                                    <td>{OpeningFactorLim}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Walls Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{wallName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{wallDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{wallSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{wallThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Floor Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{floorName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{floorDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{floorSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{floorThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Ceiling Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{ceilingName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{ceilingDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{ceilingSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{ceilingThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Thermal Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Wall Thermal Inertia (J/(m²·K))</th>
                                    <td>{WallThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Floor Thermal Inertia (J/(m²·K))</th>
                                    <td>{FloorThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Ceiling Thermal Inertia (J/(m²·K))</th>
                                    <td>{CeilingThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Compartment Thermal Inertia (J/(m²·K))</th>
                                    <td>{CompartmentThermalInertia}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Design Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Occupancy Type</th>
                                    <td>{OccupancyType}</td>
                                </tr>
                                <tr>
                                    <th>Fire Growth Rate</th>
                                    <td>{FireGrowthRate}</td>
                                </tr>
                                <tr>
                                    <th>Fire Load Density (q_fk) MJ·m⁻²</th>
                                    <td>{FireLoadDensity}</td>
                                </tr>
                                <tr>
                                    <th>Design Fire Load Density (q_fd) MJ·m⁻²</th>
                                    <td>{DesignFireLoadDensity}</td>
                                </tr>
                                <tr>
                                    <th>Total Design Fire Load (q_td) MJ·m⁻²</th>
                                    <td>{TotalDesignFireLoad}</td>
                                </tr>
                                <tr>
                                    <th>ROFI - Occupancy (gama_1)</th>
                                    <td>{ROFI_Occupancy}</td>
                                </tr>
                                <tr>
                                    <th>ROFI - Floor Area (gama_2)</th>
                                    <td>{ROFI_FloorArea}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Time Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Limiting Time (hour)</th>
                                    <td>{LimitingTime}</td>
                                </tr>
                                <tr>
                                    <th>Fire Duration (minutes)</th>
                                    <td>{FireDuration}</td>
                                </tr>
                                <tr>
                                    <th>Time Factor</th>
                                    <td>{TimeFactor}</td>
                                </tr>
                                <tr>
                                    <th>Time Factor Lim</th>
                                    <td>{TimeFactorLim}</td>
                                </tr>
                                <tr>
                                    <th>t_max</th>
                                    <td>{t_max}</td>
                                </tr>
                                <tr>
                                    <th>t_max_2</th>
                                    <td>{t_max_2}</td>
                                </tr>
                                <tr>
                                    <th>t_max_3</th>
                                    <td>{t_max_3}</td>
                                </tr>
                                <tr>
                                    <th>t_max_4</th>
                                    <td>{t_max_4}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Other Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Combustion Factor</th>
                                    <td>{CombustionFactor}</td>
                                </tr>
                                <tr>
                                    <th>Active Fire Coefficient</th>
                                    <td>{ActiveFireCoefficient}</td>
                                </tr>
                            </table>
                        </div>

                        <!-- Interactive Graph Section -->
                        <div class=""section"">
                            <div class=""section-title"">Temperature vs Time Graph</div>
                            <canvas id=""temperatureGraph""></canvas>
                        </div>
                    </div>

                    <script>
                           var ctx = document.getElementById('temperatureGraph').getContext('2d');
                var temperatureGraph;

                function createGraph(labels, data) {
                    if (temperatureGraph) {
                        temperatureGraph.destroy();
                    }
    
                    temperatureGraph = new Chart(ctx, {
                        type: 'line',
                        data: {
                            labels: labels,
                            datasets: [{
                                label: 'Temperature (°C)',
                                data: data,
                                borderColor: 'rgba(75, 192, 192, 1)',
                                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                borderWidth: 2,
                                pointRadius: 1,
                                pointHoverRadius: 2,
                            }]
                        },
                        options: {
                            responsive: true,
                            maintainAspectRatio: true,
                            scales: {
                                x: {
                                    title: {
                                        display: true,
                                        text: 'Time (minutes)'
                                    }
                                },
                                y: {
                                    title: {
                                        display: true,
                                        text: 'Temperature (°C)'
                                    },
                                    beginAtZero: true,
                                }
                            }
                        }
                    });
                }

                // Simulate CSV data processing
                function simulateCsvData() {
                    const csvData = 
                        {csv_data}
                    ; 
    
                    processData(csvData);
                }

                function processData(csvData) {
                    var lines = csvData.trim().split('\n');
                    var labels = [];
                    var data = [];

                    for (var i = 0; i < lines.length; i += 5) {
                        var line = lines[i].trim();
                        if (line) {
                            var parts = line.split(' ');
                            var timeInSeconds = parseInt(parts[0]);
                            var temperature = parseFloat(parts[1]);

                            var timeInMinutes = (timeInSeconds / 60).toFixed(2);
                            labels.push(timeInMinutes);
                            data.push(temperature);
                        }
                    }

                    createGraph(labels, data);
                }

                simulateCsvData();

                document.querySelector('button').addEventListener('click', function() {
                    alert('Maximum Temperature Time is {MaxTemperatureTime} minutes for curve {CurveName}');
                });
                </script>
                </body>
                </html>

        ";
            Fuel_HTML_Report = @"<!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Report - {ReportTitle}</title>
                    <!-- Include Chart.js from a CDN -->
                    <script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>
                    <style>
                        * {
                            margin: 0;
                            padding: 0;
                            box-sizing: border-box;
                        }

                        body {
                            font-size: 1rem;
                            font-family: 'Arial', sans-serif;
                            background-color: #f0f4f8;
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            min-height: 100vh;
                            margin: 0;
                            padding: 0;
                        }

                        .report-container {
                            background-color: #ffffff;
                            padding: 30px;
                            border-radius: 10px;
                            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                            max-width: 800px;
                            width: 75%;
                            margin: 20px;
                        }

                        .header {
                            display: flex;
                            justify-content: space-between;
                            align-items: center;
                            margin-bottom: 20px;
                            border-bottom: 2px solid #007bff;
                            padding-bottom: 10px;
                        }

                        .header h1 {
                            margin: 0;
                            font-size: 1.5rem;
                            color: #333;
                        }

                        .header p {
                            margin: 0;
                            color: #666;
                            font-size: 0.9rem;
                        }

                        .section {
                            margin-bottom: 30px;
                        }

                        .section-title {
                            font-size: 20px;
                            color: #555;
                            margin-bottom: 15px;
                            border-bottom: 2px solid #ddd;
                            padding-bottom: 8px;
                            text-align: left;
                        }

                        .property-table {
                            width: 100%;
                            border-collapse: separate;
                            margin-top: 15px;
                        }

                        .property-table th, .property-table td {
                            padding: 12px;
                            text-align: left; 
                            border-bottom: 1px solid #ddd;
                        }

                        .property-table th {
                            background-color: #f2f2f2;
                            color: #333;
                            width: 60%;
                        }

                        .property-table td {
                            background-color: #fafafa;
                        }

                        .interactive {
                            margin-top: 20px;
                            text-align: center;
                        }

                        button {
                            padding: 12px 25px;
                            font-size: 16px;
                            color: white;
                            background-color: #007bff;
                            border: none;
                            border-radius: 5px;
                            cursor: pointer;
                            transition: background-color 0.3s ease;
                        }

                        button:hover {
                            background-color: #0056b3;
                        }

                        /* Media Queries for Responsiveness */
                        @media (max-width: 768px) {
                            .report-container {
                                width: 90%;
                                padding: 15px;
                            }

                            .header h1 {
                                font-size: 1rem;
                            }

                            .section-title {
                                font-size: 18px;
                            }

                            .property-table th, .property-table td {
                                padding: 10px;
                                font-size: 0.9rem;
                            }

                            .header p {
                                font-size: 0.7rem;
                                margin-top: 3px;
                            }
                        }

                        @media (max-width: 480px) {
                            .report-container {
                                width: 95%;
                                padding: 10px;
                            }

                            .header {
                                flex-direction: column;
                                align-items: flex-start;
                            }

                            .header h1 {
                                font-size: 0.8rem;
                            }

                            button {
                                width: 100%;
                                padding: 10px 0;
                            }
                        }

                        /* Style to properly contain the canvas element */
                        #temperatureGraph {
                            max-height: 400px;
                            width: 100%;
                        }
                    </style>
                </head>
                <body>
                    <div class=""report-container"">
                        <div class=""header"">
                            <h1>{ReportTitle}</h1>
                            <p>{ReportDate}</p>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Curve Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Curve Name</th>
                                    <td>{CurveName}</td>
                                </tr>
                                <tr>
                                    <th>Curve Code</th>
                                    <td>{CurveCode}</td>
                                </tr>
                                <tr>
                                    <th>Fire Type</th>
                                    <td>{FireType}</td>
                                </tr>
                                <tr>
                                    <th>Maximum Temperature (°C)</th>
                                    <td>{MaxTemperature}</td>
                                </tr>
                                <tr>
                                    <th>Maximum Temperature Time (minutes)</th>
                                    <td>{MaxTemperatureTime}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Compartment Dimensions</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Length (m)</th>
                                    <td>{Length}</td>
                                </tr>
                                <tr>
                                    <th>Width (m)</th>
                                    <td>{Width}</td>
                                </tr>
                                <tr>
                                    <th>Height (m)</th>
                                    <td>{Height}</td>
                                </tr>
                                <tr>
                                    <th>Floor Area (m²)</th>
                                    <td>{FloorArea}</td>
                                </tr>
                                <tr>
                                    <th>Ceiling Area (m²)</th>
                                    <td>{CeilingArea}</td>
                                </tr>
                                <tr>
                                    <th>Walls Area (m²)</th>
                                    <td>{WallsArea}</td>
                                </tr>
                                <tr>
                                    <th>Enclosure Area (m²)</th>
                                    <td>{EnclosureArea}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Opening Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Opening Area (m²)</th>
                                    <td>{OpeningArea}</td>
                                </tr>
                                <tr>
                                    <th>Average Height (m)</th>
                                    <td>{AverageHeight}</td>
                                </tr>
                                <tr>
                                    <th>Opening Factor (m½)</th>
                                    <td>{OpeningFactor}</td>
                                </tr>
                                <tr>
                                    <th>Opening Factor Lim (m½)</th>
                                    <td>{OpeningFactorLim}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Walls Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{wallName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{wallDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{wallSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{wallThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Floor Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{floorName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{floorDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{floorSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{floorThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>
                        <div class=""section"">
                            <div class=""section-title"">Ceiling Material</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Name</th>
                                    <td>{ceilingName}</td>
                                </tr>
                                <tr>
                                    <th>Density (J/(m²·K))</th>
                                    <td>{ceilingDensity}</td>
                                </tr>
                                <tr>
                                    <th>Specific Heat (J/(m²·K))</th>
                                    <td>{ceilingSpecificHeat}</td>
                                </tr>
                                <tr>
                                    <th>Thermal Conductivity(J/(m²·K))</th>
                                    <td>{ceilingThermalConductivity}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Thermal Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Wall Thermal Inertia (J/(m²·K))</th>
                                    <td>{WallThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Floor Thermal Inertia (J/(m²·K))</th>
                                    <td>{FloorThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Ceiling Thermal Inertia (J/(m²·K))</th>
                                    <td>{CeilingThermalInertia}</td>
                                </tr>
                                <tr>
                                    <th>Compartment Thermal Inertia (J/(m²·K))</th>
                                    <td>{CompartmentThermalInertia}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Design Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Occupancy Type</th>
                                    <td>{OccupancyType}</td>
                                </tr>
                                <tr>
                                    <th>Fire Growth Rate</th>
                                    <td>{FireGrowthRate}</td>
                                </tr>
                                <tr>
                                    <th>Fire Load Density (q_fk) MJ·m⁻²</th>
                                    <td>{FireLoadDensity}</td>
                                </tr>
                                <tr>
                                    <th>Design Fire Load Density (q_fd) MJ·m⁻²</th>
                                    <td>{DesignFireLoadDensity}</td>
                                </tr>
                                <tr>
                                    <th>Total Design Fire Load (q_td) MJ·m⁻²</th>
                                    <td>{TotalDesignFireLoad}</td>
                                </tr>
                                <tr>
                                    <th>ROFI - Occupancy (gama_1)</th>
                                    <td>{ROFI_Occupancy}</td>
                                </tr>
                                <tr>
                                    <th>ROFI - Floor Area (gama_2)</th>
                                    <td>{ROFI_FloorArea}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Time Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Limiting Time (hour)</th>
                                    <td>{LimitingTime}</td>
                                </tr>
                                <tr>
                                    <th>Fire Duration (minutes)</th>
                                    <td>{FireDuration}</td>
                                </tr>
                                <tr>
                                    <th>Time Factor</th>
                                    <td>{TimeFactor}</td>
                                </tr>
                                <tr>
                                    <th>Time Factor Lim</th>
                                    <td>{TimeFactorLim}</td>
                                </tr>
                                <tr>
                                    <th>t_max</th>
                                    <td>{t_max}</td>
                                </tr>
                                <tr>
                                    <th>t_max_2</th>
                                    <td>{t_max_2}</td>
                                </tr>
                                <tr>
                                    <th>t_max_3</th>
                                    <td>{t_max_3}</td>
                                </tr>
                                <tr>
                                    <th>t_max_4</th>
                                    <td>{t_max_4}</td>
                                </tr>
                            </table>
                        </div>

                        <div class=""section"">
                            <div class=""section-title"">Other Properties</div>
                            <table class=""property-table"">
                                <tr>
                                    <th>Combustion Factor</th>
                                    <td>{CombustionFactor}</td>
                                </tr>
                                <tr>
                                    <th>Active Fire Coefficient</th>
                                    <td>{ActiveFireCoefficient}</td>
                                </tr>
                            </table>
                        </div>

                        <!-- Interactive Graph Section -->
                        <div class=""section"">
                            <div class=""section-title"">Temperature vs Time Graph</div>
                            <canvas id=""temperatureGraph""></canvas>
                        </div>
                    </div>

                <script>
                        var ctx = document.getElementById('temperatureGraph').getContext('2d');
                        var temperatureGraph;

                        function createGraph(labels, data) {
                            if (temperatureGraph) {
                                temperatureGraph.destroy();
                            }

                            temperatureGraph = new Chart(ctx, {
                                type: 'line',
                                data: {
                                    labels: labels,
                                    datasets: [{
                                        label: 'Temperature (°C)',
                                        data: data,
                                        borderColor: 'rgba(75, 192, 192, 1)',
                                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                        borderWidth: 2,
                                        pointRadius: 1,
                                        pointHoverRadius: 2,
                                    }]
                                },
                                options: {
                                    responsive: true,
                                    maintainAspectRatio: true,
                                    scales: {
                                        x: {
                                            title: {
                                                display: true,
                                                text: 'Time (minutes)'
                                            }
                                        },
                                        y: {
                                            title: {
                                                display: true,
                                                text: 'Temperature (°C)'
                                            },
                                            beginAtZero: true,
                                        }
                                    }
                                }
                            });
                        }

                        // Use the Times and Temperatures directly if this is a ""_Report""
                        var times = {js_times};
                        var temperatures = {js_temperatures};

                        createGraph(times, temperatures);
                    </script>
                </body>
                </html>

        ";

        }
        public void EditHTML_Ventilation()
        {
            Ventilation_HTML = Ventilation_HTML.Replace("{ReportTitle}", CurveTitle ?? "N/A")
            .Replace("{ReportDate}", DateTime.Now.ToString("dd.MM.yyyy"))
            .Replace("{CurveName}", CurveName ?? "N/A")
            .Replace("{CurveCode}", CurveCode ?? "N/A")
            .Replace("{FireType}", FireType ?? "N/A")
            .Replace("{MaxTemperature}", MaximumTemperature.ToString("0.000"))
            .Replace("{MaxTemperatureTime}", MaximumTemperatureTime.ToString("0.000"))

            // Replace compartment dimensions
            .Replace("{Length}", Length.ToString("0.00"))
            .Replace("{Width}", Width.ToString("0.00"))
            .Replace("{Height}", Height.ToString("0.00"))
            .Replace("{FloorArea}", FloorArea.ToString("0.00"))
            .Replace("{CeilingArea}", CeilingArea.ToString("0.00"))
            .Replace("{WallsArea}", WallsArea.ToString("0.00"))
            .Replace("{EnclosureArea}", EnclosureArea.ToString("0.00"))

            // Replace opening properties
            .Replace("{OpeningArea}", OpeningArea.ToString("0.00"))
            .Replace("{AverageHeight}", AverageHeight.ToString("0.00"))
            .Replace("{OpeningFactor}", OpeningFactor.ToString("0.00"))

            // Replace wall material properties
            .Replace("{wallName}", WallMaterial.Name)
            .Replace("{wallDensity}", WallMaterial.Density.ToString("0.00"))
            .Replace("{wallSpecificHeat}", WallMaterial.SpecificHeat.ToString("0.00"))
            .Replace("{wallThermalConductivity}", WallMaterial.ThermalConductivity.ToString("0.00"))

            // Replace floor material properties
            .Replace("{floorName}", FloorMaterial.Name)
            .Replace("{floorDensity}", FloorMaterial.Density.ToString("0.00"))
            .Replace("{floorSpecificHeat}", FloorMaterial.SpecificHeat.ToString("0.00"))
            .Replace("{floorThermalConductivity}", FloorMaterial.ThermalConductivity.ToString("0.00"))

            // Replace ceiling material properties
            .Replace("{ceilingName}", CeilingMaterial.Name)
            .Replace("{ceilingDensity}", CeilingMaterial.Density.ToString("0.00"))
            .Replace("{ceilingSpecificHeat}", CeilingMaterial.SpecificHeat.ToString("0.00"))
            .Replace("{ceilingThermalConductivity}", CeilingMaterial.ThermalConductivity.ToString("0.00"))

            // Replace thermal inertia values
            .Replace("{WallThermalInertia}", WallThermalInertia.ToString("0.00"))
            .Replace("{FloorThermalInertia}", FloorThermalInertia.ToString("0.00"))
            .Replace("{CeilingThermalInertia}", CeilingThermalInertia.ToString("0.00"))
            .Replace("{CompartmentThermalInertia}", CompartmentThermalInertia.ToString("0.00"))

            // Replace design properties
            .Replace("{OccupancyType}", OccupancyType)
            .Replace("{FireGrowthRate}", FireGrowthRate.ToString())
            .Replace("{FireLoadDensity}", DesignValue_q_fk.ToString("0.00"))
            .Replace("{DesignFireLoadDensity}", FireDesignLoad_q_fd.ToString("0.00"))
            .Replace("{TotalDesignFireLoad}", TotalDesignFireLoad_q_td.ToString("0.00"))
            .Replace("{ROFI_Occupancy}", ROFI_Occupancy_gama_1.ToString("0.00"))
            .Replace("{ROFI_FloorArea}", ROFI_FloorArea_gama_2.ToString("0.00"))

            // Replace time properties
            .Replace("{LimitingTime}", LimitingTime_t_lim.ToString("0.00"))
            .Replace("{FireDuration}", FireDuration.ToString("0.00"))
            .Replace("{TimeFactor}", TimeFactor.ToString("0.00"))
            .Replace("{t_max}", t_max.ToString("0.00"))
            .Replace("{t_max_2}", t_max_2.ToString("0.00"))

            // Replace other properties
            .Replace("{CombustionFactor}", CombustionFactor_m.ToString("0.00"))
            .Replace("{ActiveFireCoefficient}", ActiveSuppressionCoefficient_gama_n.ToString("0.00"));
        }

        public void EditHTML_Ventilation_Report()
        {
            // Generate JavaScript data for times and temperatures
            string jsGraphDataTimes = CreateJavaScriptArray(Times);
            string jsGraphDataTemperatures = CreateJavaScriptArray(Temperatures);

            // Replace placeholders in the HTML report template with actual data
            Ventilation_HTML_Report = Ventilation_HTML_Report.Replace("{ReportTitle}", CurveTitle ?? "N/A")
                .Replace("{ReportDate}", DateTime.Now.ToString("dd.MM.yyyy"))
                .Replace("{CurveName}", CurveName ?? "N/A")
                .Replace("{CurveCode}", CurveCode ?? "N/A")
                .Replace("{FireType}", FireType ?? "N/A")
                .Replace("{MaxTemperature}", MaximumTemperature.ToString("0.000"))
                .Replace("{MaxTemperatureTime}", MaximumTemperatureTime.ToString("0.000"))

                // Replace placeholders for compartment dimensions
                .Replace("{Length}", Length.ToString("0.00"))
                .Replace("{Width}", Width.ToString("0.00"))
                .Replace("{Height}", Height.ToString("0.00"))
                .Replace("{FloorArea}", FloorArea.ToString("0.00"))
                .Replace("{CeilingArea}", CeilingArea.ToString("0.00"))
                .Replace("{WallsArea}", WallsArea.ToString("0.00"))
                .Replace("{EnclosureArea}", EnclosureArea.ToString("0.00"))

                // Replace placeholders for opening properties
                .Replace("{OpeningArea}", OpeningArea.ToString("0.00"))
                .Replace("{AverageHeight}", AverageHeight.ToString("0.00"))
                .Replace("{OpeningFactor}", OpeningFactor.ToString("0.00"))

                // Replace placeholders for wall material properties
                .Replace("{wallName}", WallMaterial.Name)
                .Replace("{wallDensity}", WallMaterial.Density.ToString("0.00"))
                .Replace("{wallSpecificHeat}", WallMaterial.SpecificHeat.ToString("0.00"))
                .Replace("{wallThermalConductivity}", WallMaterial.ThermalConductivity.ToString("0.00"))

                // Replace placeholders for floor material properties
                .Replace("{floorName}", FloorMaterial.Name)
                .Replace("{floorDensity}", FloorMaterial.Density.ToString("0.00"))
                .Replace("{floorSpecificHeat}", FloorMaterial.SpecificHeat.ToString("0.00"))
                .Replace("{floorThermalConductivity}", FloorMaterial.ThermalConductivity.ToString("0.00"))

                // Replace placeholders for ceiling material properties
                .Replace("{ceilingName}", CeilingMaterial.Name)
                .Replace("{ceilingDensity}", CeilingMaterial.Density.ToString("0.00"))
                .Replace("{ceilingSpecificHeat}", CeilingMaterial.SpecificHeat.ToString("0.00"))
                .Replace("{ceilingThermalConductivity}", CeilingMaterial.ThermalConductivity.ToString("0.00"))

                // Replace placeholders for thermal inertia properties
                .Replace("{WallThermalInertia}", WallThermalInertia.ToString("0.00"))
                .Replace("{FloorThermalInertia}", FloorThermalInertia.ToString("0.00"))
                .Replace("{CeilingThermalInertia}", CeilingThermalInertia.ToString("0.00"))
                .Replace("{CompartmentThermalInertia}", CompartmentThermalInertia.ToString("0.00"))

                // Replace placeholders for design properties
                .Replace("{OccupancyType}", OccupancyType)
                .Replace("{FireGrowthRate}", FireGrowthRate.ToString())
                .Replace("{FireLoadDensity}", DesignValue_q_fk.ToString("0.00"))
                .Replace("{DesignFireLoadDensity}", FireDesignLoad_q_fd.ToString("0.00"))
                .Replace("{TotalDesignFireLoad}", TotalDesignFireLoad_q_td.ToString("0.00"))
                .Replace("{ROFI_Occupancy}", ROFI_Occupancy_gama_1.ToString("0.00"))
                .Replace("{ROFI_FloorArea}", ROFI_FloorArea_gama_2.ToString("0.00"))

                // Replace placeholders for time properties
                .Replace("{LimitingTime}", LimitingTime_t_lim.ToString("0.00"))
                .Replace("{FireDuration}", FireDuration.ToString("0.00"))
                .Replace("{TimeFactor}", TimeFactor.ToString("0.00"))
                .Replace("{t_max}", t_max.ToString("0.00"))
                .Replace("{t_max_2}", t_max_2.ToString("0.00"))

                // Replace placeholders for other properties
                .Replace("{CombustionFactor}", CombustionFactor_m.ToString("0.00"))
                .Replace("{ActiveFireCoefficient}", ActiveSuppressionCoefficient_gama_n.ToString("0.00"))

                // Replace the JavaScript arrays for times and temperatures
                .Replace("{js_times}", jsGraphDataTimes)
                .Replace("{js_temperatures}", jsGraphDataTemperatures);

            // Now Ventilation_HTML_Report is fully populated with the dynamic data
        }


        public void EditHTML_Fuel()
        {
            Fuel_HTML = Fuel_HTML.Replace("{ReportTitle}", CurveTitle ?? "N/A")
                .Replace("{ReportDate}", DateTime.Now.ToString("dd.MM.yyyy"))
                .Replace("{CurveName}", CurveName ?? "N/A")
                .Replace("{CurveCode}", CurveCode ?? "N/A")
                .Replace("{FireType}", FireType ?? "N/A")
                .Replace("{MaxTemperature}", MaximumTemperature.ToString("0.000"))
                .Replace("{MaxTemperatureTime}", MaximumTemperatureTime.ToString("0.000"))

                // Replace compartment dimensions
                .Replace("{Length}", Length.ToString("0.00"))
                .Replace("{Width}", Width.ToString("0.00"))
                .Replace("{Height}", Height.ToString("0.00"))
                .Replace("{FloorArea}", FloorArea.ToString("0.00"))
                .Replace("{CeilingArea}", CeilingArea.ToString("0.00"))
                .Replace("{WallsArea}", WallsArea.ToString("0.00"))
                .Replace("{EnclosureArea}", EnclosureArea.ToString("0.00"))

                // Replace opening properties
                .Replace("{OpeningArea}", OpeningArea.ToString("0.00"))
                .Replace("{AverageHeight}", AverageHeight.ToString("0.00"))
                .Replace("{OpeningFactor}", OpeningFactor.ToString("0.00"))
                .Replace("{OpeningFactorLim}", OpeningFactor_Lim.ToString("0.00"))

                // Replace wall material properties
                .Replace("{wallName}", WallMaterial.Name)
                .Replace("{wallDensity}", WallMaterial.Density.ToString("0.00"))
                .Replace("{wallSpecificHeat}", WallMaterial.SpecificHeat.ToString("0.00"))
                .Replace("{wallThermalConductivity}", WallMaterial.ThermalConductivity.ToString("0.00"))

                // Replace floor material properties
                .Replace("{floorName}", FloorMaterial.Name)
                .Replace("{floorDensity}", FloorMaterial.Density.ToString("0.00"))
                .Replace("{floorSpecificHeat}", FloorMaterial.SpecificHeat.ToString("0.00"))
                .Replace("{floorThermalConductivity}", FloorMaterial.ThermalConductivity.ToString("0.00"))

                // Replace ceiling material properties
                .Replace("{ceilingName}", CeilingMaterial.Name)
                .Replace("{ceilingDensity}", CeilingMaterial.Density.ToString("0.00"))
                .Replace("{ceilingSpecificHeat}", CeilingMaterial.SpecificHeat.ToString("0.00"))
                .Replace("{ceilingThermalConductivity}", CeilingMaterial.ThermalConductivity.ToString("0.00"))

                // Replace thermal inertia values
                .Replace("{WallThermalInertia}", WallThermalInertia.ToString("0.00"))
                .Replace("{FloorThermalInertia}", FloorThermalInertia.ToString("0.00"))
                .Replace("{CeilingThermalInertia}", CeilingThermalInertia.ToString("0.00"))
                .Replace("{CompartmentThermalInertia}", CompartmentThermalInertia.ToString("0.00"))

                // Replace design properties
                .Replace("{OccupancyType}", OccupancyType)
                .Replace("{FireGrowthRate}", FireGrowthRate.ToString())
                .Replace("{FireLoadDensity}", DesignValue_q_fk.ToString("0.00"))
                .Replace("{DesignFireLoadDensity}", FireDesignLoad_q_fd.ToString("0.00"))
                .Replace("{TotalDesignFireLoad}", TotalDesignFireLoad_q_td.ToString("0.00"))
                .Replace("{ROFI_Occupancy}", ROFI_Occupancy_gama_1.ToString("0.00"))
                .Replace("{ROFI_FloorArea}", ROFI_FloorArea_gama_2.ToString("0.00"))

                // Replace time properties
                .Replace("{LimitingTime}", LimitingTime_t_lim.ToString("0.00"))
                .Replace("{FireDuration}", FireDuration.ToString("0.00"))
                .Replace("{TimeFactor}", TimeFactor.ToString("0.00"))
                .Replace("{TimeFactorLim}", TimeFactor_Lim.ToString("0.00"))
                .Replace("{t_max}", t_max.ToString("0.00"))
                .Replace("{t_max_2}", t_max_2.ToString("0.00"))
                .Replace("{t_max_3}", t_max_3.ToString("0.00"))
                .Replace("{t_max_4}", t_max_4.ToString("0.00"))

                // Replace other properties
                .Replace("{CombustionFactor}", CombustionFactor_m.ToString("0.00"))
                .Replace("{ActiveFireCoefficient}", ActiveSuppressionCoefficient_gama_n.ToString("0.00"));
        }


        public void EditHTML_Fuel_Report()
        {

            string jsGraphDataTimes = CreateJavaScriptArray(Times);
            string jsGraphDataTemperatures = CreateJavaScriptArray(Temperatures);


            Fuel_HTML_Report = Fuel_HTML_Report.Replace("{ReportTitle}", CurveTitle ?? "N/A")
            .Replace("{ReportDate}", DateTime.Now.ToString("dd.MM.yyyy"))
            .Replace("{CurveName}", CurveName ?? "N/A")
            .Replace("{CurveCode}", CurveCode ?? "N/A")
            .Replace("{FireType}", FireType ?? "N/A")
            .Replace("{MaxTemperature}", MaximumTemperature.ToString("0.000"))
            .Replace("{MaxTemperatureTime}", MaximumTemperatureTime.ToString("0.000"))
            .Replace("{Length}", Length.ToString("0.000"))
            .Replace("{Width}", Width.ToString("0.000"))
            .Replace("{Height}", Height.ToString("0.000"))
            .Replace("{FloorArea}", FloorArea.ToString("0.000"))
            .Replace("{CeilingArea}", CeilingArea.ToString("0.000"))
            .Replace("{WallsArea}", WallsArea.ToString("0.000"))
            .Replace("{EnclosureArea}", EnclosureArea.ToString("0.000"))
            .Replace("{OpeningArea}", OpeningArea.ToString("0.000"))
            .Replace("{AverageHeight}", AverageHeight.ToString("0.000"))
            .Replace("{OpeningFactor}", OpeningFactor.ToString("0.000"))
            .Replace("{OpeningFactorLim}", OpeningFactor_Lim.ToString("0.000"))
            .Replace("{wallName}", WallMaterial.Name)
            .Replace("{wallDensity}", WallMaterial.Density.ToString("0.000"))
            .Replace("{wallSpecificHeat}", WallMaterial.SpecificHeat.ToString("0.000"))
            .Replace("{wallThermalConductivity}", WallMaterial.ThermalConductivity.ToString("0.000"))
            .Replace("{floorName}", FloorMaterial.Name)
            .Replace("{floorDensity}", FloorMaterial.Density.ToString("0.000"))
            .Replace("{floorSpecificHeat}", FloorMaterial.SpecificHeat.ToString("0.000"))
            .Replace("{floorThermalConductivity}", FloorMaterial.ThermalConductivity.ToString("0.000"))
            .Replace("{ceilingName}", CeilingMaterial.Name)
            .Replace("{ceilingDensity}", CeilingMaterial.Density.ToString("0.000"))
            .Replace("{ceilingSpecificHeat}", CeilingMaterial.SpecificHeat.ToString("0.000"))
            .Replace("{ceilingThermalConductivity}", CeilingMaterial.ThermalConductivity.ToString("0.000"))
            .Replace("{WallThermalInertia}", WallThermalInertia.ToString("0.000"))
            .Replace("{FloorThermalInertia}", FloorThermalInertia.ToString("0.000"))
            .Replace("{CeilingThermalInertia}", CeilingThermalInertia.ToString("0.000"))
            .Replace("{CompartmentThermalInertia}", CompartmentThermalInertia.ToString("0.000"))
            .Replace("{OccupancyType}", OccupancyType)
            .Replace("{FireGrowthRate}", FireGrowthRate.ToString())
            .Replace("{FireLoadDensity}", DesignValue_q_fk.ToString("0.000"))
            .Replace("{DesignFireLoadDensity}", FireDesignLoad_q_fd.ToString("0.000"))
            .Replace("{TotalDesignFireLoad}", TotalDesignFireLoad_q_td.ToString("0.000"))
            .Replace("{ROFI_Occupancy}", ROFI_Occupancy_gama_1.ToString("0.000"))
            .Replace("{ROFI_FloorArea}", ROFI_FloorArea_gama_2.ToString("0.000"))
            .Replace("{LimitingTime}", LimitingTime_t_lim.ToString("0.000"))
            .Replace("{FireDuration}", FireDuration.ToString("0.000"))
            .Replace("{TimeFactor}", TimeFactor.ToString("0.000"))
            .Replace("{TimeFactorLim}", TimeFactor_Lim.ToString("0.000"))
            .Replace("{t_max}", t_max.ToString("0.000"))
            .Replace("{t_max_2}", t_max_2.ToString("0.000"))
            .Replace("{t_max_3}", t_max_3.ToString("0.000"))
            .Replace("{t_max_4}", t_max_4.ToString("0.000"))
            .Replace("{CombustionFactor}", CombustionFactor_m.ToString("0.000"))
            .Replace("{ActiveFireCoefficient}", ActiveSuppressionCoefficient_gama_n.ToString("0.000"))
            .Replace("{js_times}", jsGraphDataTimes)
            .Replace("{js_temperatures}", jsGraphDataTemperatures);
        }

        // Modify the CreateJavaScriptArray method to convert times from seconds to minutes
        private string CreateJavaScriptArray(List<double> values, bool convertToMinutes = true)
        {
            // Initialize StringBuilder for efficiency
            StringBuilder jsArray = new StringBuilder();
            jsArray.Append("[");

            // Iterate through the list of values and format them to two decimal places for JavaScript
            for (int i = 0; i < values.Count; i++)
            {
                double value = values[i];
                if (convertToMinutes)
                {
                    value = value / 60; // Convert seconds to minutes
                }

                // Ensure the value is properly formatted and safe for JavaScript by limiting it to 2 decimal places
                jsArray.Append(value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));

                // Add a comma separator between values, but avoid adding it after the last item
                if (i < values.Count - 1)
                {
                    jsArray.Append(", ");
                }
            }

            // Close the JavaScript array
            jsArray.Append("]");

            // Return the formatted JavaScript array as a string
            return jsArray.ToString();
        }



        // Method to export HTML to a file
        public void ExportToHTML_Ventilation(string folderPath)
        {
            // Ensure the folder path is not null or empty
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new ArgumentException("The folder path cannot be null or empty.", nameof(folderPath));
            }

            // Construct a unique file name using the curve name and the current date-time to avoid overwriting
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = $"{CurveName}_Report_{timestamp}.html";
            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                // Save the HTML content to the specified .html file
                File.WriteAllText(filePath, Ventilation_HTML);

            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("You do not have permission to save files in this location. Please choose a different folder.");
            }
            catch (IOException ioEx)
            {
                throw new IOException($"An IO error occurred while exporting the HTML file: {ioEx.Message}", ioEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred while exporting the HTML file: {ex.Message}", ex);
            }
        }

        public void ExportToHTML_Ventilation_Report(string folderPath)
        {
            // Ensure the folder path is not null or empty
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new ArgumentException("The folder path cannot be null or empty.", nameof(folderPath));
            }

            // Construct a unique file name using the curve name and the current date-time to avoid overwriting
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = $"{CurveName}_Report_{timestamp}.html";
            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                // Save the HTML content to the specified .html file
                File.WriteAllText(filePath, Ventilation_HTML_Report);

            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("You do not have permission to save files in this location. Please choose a different folder.");
            }
            catch (IOException ioEx)
            {
                throw new IOException($"An IO error occurred while exporting the HTML file: {ioEx.Message}", ioEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred while exporting the HTML file: {ex.Message}", ex);
            }
        }
        public void ExportToHTML_Fuel(string folderPath)
        {
            // Ensure the folder path is not null or empty
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new ArgumentException("The folder path cannot be null or empty.", nameof(folderPath));
            }

            // Construct a unique file name using the curve name and the current date-time to avoid overwriting
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{CurveName}_Report_{timestamp}.html";
            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                // Save the HTML content to the specified .html file
                File.WriteAllText(filePath, Fuel_HTML);

            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("You do not have permission to save files in this location. Please choose a different folder.");
            }
            catch (IOException ioEx)
            {
                throw new IOException($"An IO error occurred while exporting the HTML file: {ioEx.Message}", ioEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred while exporting the HTML file: {ex.Message}", ex);
            }
        }

        public void ExportToHTML_Fuel_Report(string folderPath)
        {
            // Ensure the folder path is not null or empty
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new ArgumentException("The folder path cannot be null or empty.", nameof(folderPath));
            }

            // Construct a unique file name using the curve name and the current date-time to avoid overwriting
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{CurveName}_Report_{timestamp}.html";
            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                // Save the HTML content to the specified .html file
                File.WriteAllText(filePath, Fuel_HTML_Report);

            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("You do not have permission to save files in this location. Please choose a different folder.");
            }
            catch (IOException ioEx)
            {
                throw new IOException($"An IO error occurred while exporting the HTML file: {ioEx.Message}", ioEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred while exporting the HTML file: {ex.Message}", ex);
            }
        }


        private string CreateCSV()
        {
            StringBuilder csvData = new StringBuilder();

            for (int i = 0; i < Times.Count; i++)
            {
                csvData.AppendLine($"{Times[i]/60} {Temperatures[i]}");
            }

            return csvData.ToString();
        }

    }
}
