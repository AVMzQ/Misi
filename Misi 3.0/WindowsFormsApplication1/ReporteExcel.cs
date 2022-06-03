using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Excel
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using SpreadsheetLight.Drawing;
//sql
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    class ReporteExcel
    {
        private string Fecha;
        private DataGridView Tabla1;
        private DataGridView Tabla2;

        public ReporteExcel(string Fecha, DataGridView Tabla1)
        {
            this.Fecha = Fecha;
            this.Tabla1 = Tabla1;
            this.Tabla2 = Tabla2;
            GenerarExcelVenta(Fecha, Tabla1,Tabla2);
            //GenerarExcelDetalleVenta(Fecha, Tabla2);
        }

        private void GenerarExcelVenta(string Fecha, DataGridView Tabla, DataGridView tabla1)
        {
            SqlConnection con = Conexion.cadena();
            SLDocument doc = new SLDocument();

            doc.SetCellValue("D2", "Misi");
            doc.MergeWorksheetCells("D2", "G2");
            SLStyle borde = doc.CreateStyle();
            borde.Border.LeftBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borde.Border.RightBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.RightBorder.Color = System.Drawing.Color.Black;
            borde.Border.TopBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.TopBorder.Color = System.Drawing.Color.Black;
            borde.Border.BottomBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.BottomBorder.Color = System.Drawing.Color.Black;

            //================================
            SLStyle estilo = doc.CreateStyle();
            estilo.Font.FontName = "Times New Roman";
            estilo.Font.FontSize = 30;
            estilo.Font.FontColor = System.Drawing.Color.Red;
            estilo.Font.Bold = true;
            estilo.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            doc.SetCellStyle("D2", estilo);
            doc.SetCellValue("D3", "Ventas");
            doc.MergeWorksheetCells("D3", "G3");
            SLStyle estilo2 = doc.CreateStyle();
            estilo2.Font.FontName = "Century Gothic";
            estilo2.Font.FontSize = 10;
            estilo2.Font.FontColor = System.Drawing.Color.Black;
            estilo2.Font.Bold = true;
            estilo2.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            doc.SetCellStyle("D3", estilo2);

            doc.SetCellValue("D4", Fecha);
            doc.MergeWorksheetCells("D4", "G4");
            SLStyle estilo1 = doc.CreateStyle();
            estilo1.Font.FontName = "Century Gothic";
            estilo1.Font.FontSize = 10;
            estilo1.Font.FontColor = System.Drawing.Color.Black;
            estilo1.Font.Bold = true;
            estilo1.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            doc.SetCellStyle("D4", estilo1);
            //==================================================================
            //Datos de tabla
            SLStyle es = doc.CreateStyle();
            es.Font.FontSize = 10;
            es.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            es.Font.Bold = true;
            doc.SetCellValue("B6", "Codigo");
            doc.MergeWorksheetCells("B6", "C6");
            doc.SetCellStyle("B6", es);

            doc.SetCellValue("D6", "Total por Domicilio");
            doc.MergeWorksheetCells("D6", "E6");
            doc.SetCellStyle("D6", es);

            doc.SetCellValue("F6", "ID del Empleado");
            doc.MergeWorksheetCells("F6", "G6");
            doc.SetCellStyle("F6", es);

            doc.SetCellValue("H6", "Monto Acumulado");
            doc.MergeWorksheetCells("H6", "I6");
            doc.SetCellStyle("H6", es);
            doc.MergeWorksheetCells("B5", "I5");
            //=================================================================
            //llenar con datos del grid

            string sql = "select * from Venta"; int a = 0;
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader dr = cmd.ExecuteReader();
               
                while (dr.Read())
                {
                    if (a==0)
                    {
                        doc.SetCellValue("B7", (Convert.ToInt32(dr["Codigo"].ToString())));
                        doc.SetCellStyle("B7", es);
                        doc.MergeWorksheetCells("B7", "C7");
                        doc.SetCellValue("D7", (dr["Fecha"].ToString()));
                        doc.SetCellStyle("D7", es);
                        doc.MergeWorksheetCells("D7", "E7");
                        doc.SetCellValue("F7", dr["idEmpleado"].ToString());
                        doc.SetCellStyle("F7", es);
                        doc.MergeWorksheetCells("F7", "G7");
                        doc.SetCellValue("H7", dr["MontoAcumulado"].ToString());
                        doc.SetCellStyle("H7", es);
                        doc.MergeWorksheetCells("H7", "I7");
                        a++;
                    }
                    else
                    {
                        doc.SetCellValue("B"+(7+a)+"", (Convert.ToInt32(dr["Codigo"].ToString())));
                        doc.SetCellStyle("B"+(7+a) + "", es);
                        doc.MergeWorksheetCells("B"+(7+a) + "", "C"+(7+a) + "");
                        doc.SetCellValue("D"+(7+a) + "", (dr["Fecha"].ToString()));
                        doc.SetCellStyle("D"+(7+a) + "", es);
                        doc.MergeWorksheetCells("D"+(7+a) + "", "E"+(7+a) + "");
                        doc.SetCellValue("F"+(7+a) + "", dr["idEmpleado"].ToString());
                        doc.SetCellStyle("F"+(7+a) + "", es);
                        doc.MergeWorksheetCells("F"+(7+a) + "", "G"+(7+a) + "");
                        doc.SetCellValue("H"+(7+a) + "", dr["MontoAcumulado"].ToString());
                        doc.SetCellStyle("H"+(7+a) + "", es);
                        doc.MergeWorksheetCells("H"+(7+a) + "", "I"+(7+a) + "");
                        a++;
                    }
                }
                dr.Close();
                for (int i = 2; i < 10; i++)
                {
                    for (int j = 2; j < 7 + a; j++)
                    {

                        doc.SetCellStyle(j, i, borde);
                        doc.SetCellStyle(j, i, borde);

                    }
                }
                doc.MergeWorksheetCells("B2", "C4");
                doc.MergeWorksheetCells("H2", "I4");

            }
            //=================================================================

            doc.SetCellValue("N2", "Misi");
            doc.MergeWorksheetCells("N2", "Q2");
             borde = doc.CreateStyle();
            borde.Border.LeftBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borde.Border.RightBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.RightBorder.Color = System.Drawing.Color.Black;
            borde.Border.TopBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.TopBorder.Color = System.Drawing.Color.Black;
            borde.Border.BottomBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.BottomBorder.Color = System.Drawing.Color.Black;

            //================================
             estilo = doc.CreateStyle();
            estilo.Font.FontName = "Times New Roman";
            estilo.Font.FontSize = 30;
            estilo.Font.FontColor = System.Drawing.Color.Red;
            estilo.Font.Bold = true;
            estilo.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            doc.SetCellStyle("N2", estilo);
            doc.SetCellValue("N3", "Detalle Ventas");
            doc.MergeWorksheetCells("N3", "Q3");
            estilo2 = doc.CreateStyle();
            estilo2.Font.FontName = "Century Gothic";
            estilo2.Font.FontSize = 10;
            estilo2.Font.FontColor = System.Drawing.Color.Black;
            estilo2.Font.Bold = true;
            estilo2.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            doc.SetCellStyle("N3", estilo2);

            doc.SetCellValue("N4", Fecha);
            doc.MergeWorksheetCells("N4", "Q4");
             estilo1 = doc.CreateStyle();
            estilo1.Font.FontName = "Century Gothic";
            estilo1.Font.FontSize = 10;
            estilo1.Font.FontColor = System.Drawing.Color.Black;
            estilo1.Font.Bold = true;
            estilo1.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            doc.SetCellStyle("M4", estilo1);
            //==================================================================
            //Datos de tabla
             es = doc.CreateStyle();
            es.Font.FontSize = 10;
            es.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            es.Font.Bold = true;
            doc.SetCellValue("K6", "Codigo de medicamento");
            doc.MergeWorksheetCells("K6", "L6");
            doc.SetCellStyle("K6", es);

            doc.SetCellValue("M6", "Codigo de venta");
            doc.MergeWorksheetCells("M6", "N6");
            doc.SetCellStyle("M6", es);

            doc.SetCellValue("O6", "Cantidad");
            doc.MergeWorksheetCells("O6", "P6");
            doc.SetCellStyle("O6", es);

            doc.SetCellValue("Q6", "Fecha");
            doc.MergeWorksheetCells("Q6", "R6");
            doc.SetCellStyle("Q6", es);
            doc.MergeWorksheetCells("B5", "I5");

            doc.SetCellValue("S6", "Precio");
            doc.MergeWorksheetCells("S6", "T6");
            doc.SetCellStyle("S6", es);
            doc.MergeWorksheetCells("K5", "T5");
            //=================================================================
            //llenar con datos del grid

             sql = "select * from DetalleVenta";  a = 0;
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (a == 0)
                    {
                        doc.SetCellValue("K7", (Convert.ToInt32(dr["idMed"].ToString())));
                        doc.SetCellStyle("K7", es);
                        doc.MergeWorksheetCells("K7", "L7");
                        doc.SetCellValue("M7", (dr["idVen"].ToString()));
                        doc.SetCellStyle("M7", es);
                        doc.MergeWorksheetCells("M7", "N7");
                        doc.SetCellValue("O7", dr["Cantidad"].ToString());
                        doc.SetCellStyle("O7", es);
                        doc.MergeWorksheetCells("O7", "P7");
                        doc.SetCellValue("Q7", dr["Fecha"].ToString());
                        doc.SetCellStyle("Q7", es);
                        doc.MergeWorksheetCells("Q7", "R7");
                        doc.SetCellValue("S7", dr["Precio"].ToString());
                        doc.SetCellStyle("S7", es);
                        doc.MergeWorksheetCells("S7", "T7");


                        a++;
                    }
                    else
                    {
                        doc.SetCellValue("K" + (7 + a) + "", (Convert.ToInt32(dr["idMed"].ToString())));
                        doc.SetCellStyle("K" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("K" + (7 + a) + "", "L" + (7 + a) + "");
                        doc.SetCellValue("M" + (7 + a) + "", (dr["idVen"].ToString()));
                        doc.SetCellStyle("M" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("M" + (7 + a) + "", "N" + (7 + a) + "");
                        doc.SetCellValue("O" + (7 + a) + "", dr["Cantidad"].ToString());
                        doc.SetCellStyle("O" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("O" + (7 + a) + "", "P" + (7 + a) + "");
                        doc.SetCellValue("Q" + (7 + a) + "", dr["Fecha"].ToString());
                        doc.SetCellStyle("Q" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("Q" + (7 + a) + "", "R" + (7 + a) + "");
                        doc.SetCellValue("S" + (7 + a) + "", dr["Precio"].ToString());
                        doc.SetCellStyle("S" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("S" + (7 + a) + "", "T" + (7 + a) + "");
                        a++;
                    }
                }
                dr.Close();
                for (int i = 11; i < 21; i++)
                {
                    for (int j = 2; j < 7 + a; j++)
                    {

                        doc.SetCellStyle(j, i, borde);
                        doc.SetCellStyle(j, i, borde);

                    }
                }
                doc.MergeWorksheetCells("K2", "M4");
                doc.MergeWorksheetCells("R2", "T4");

            }
            con.Close();

            //=================================================================

            doc.SaveAs("Reporte de Ventas.xlsx");
        }

        private void GenerarExcelDetalleVenta(string Fecha, DataGridView Tabla)
        {
            SqlConnection con = Conexion.cadena();
            SLDocument doc = new SLDocument();

            doc.SetCellValue("M2", "Misi");
            doc.MergeWorksheetCells("M2", "P2");
            SLStyle borde = doc.CreateStyle();
            borde.Border.LeftBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borde.Border.RightBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.RightBorder.Color = System.Drawing.Color.Black;
            borde.Border.TopBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.TopBorder.Color = System.Drawing.Color.Black;
            borde.Border.BottomBorder.BorderStyle = BorderStyleValues.Thick;
            borde.Border.BottomBorder.Color = System.Drawing.Color.Black;

            //================================
            SLStyle estilo = doc.CreateStyle();
            estilo.Font.FontName = "Times New Roman";
            estilo.Font.FontSize = 30;
            estilo.Font.FontColor = System.Drawing.Color.Red;
            estilo.Font.Bold = true;
            estilo.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            doc.SetCellStyle("M2", estilo);
            doc.SetCellValue("M3", "Detalle Ventas");
            doc.MergeWorksheetCells("M2", "P2");
            SLStyle estilo2 = doc.CreateStyle();
            estilo2.Font.FontName = "Century Gothic";
            estilo2.Font.FontSize = 10;
            estilo2.Font.FontColor = System.Drawing.Color.Black;
            estilo2.Font.Bold = true;
            estilo2.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            doc.SetCellStyle("M3", estilo2);

            doc.SetCellValue("M4", Fecha);
            doc.MergeWorksheetCells("M4", "P4");
            SLStyle estilo1 = doc.CreateStyle();
            estilo1.Font.FontName = "Century Gothic";
            estilo1.Font.FontSize = 10;
            estilo1.Font.FontColor = System.Drawing.Color.Black;
            estilo1.Font.Bold = true;
            estilo1.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            doc.SetCellStyle("M4", estilo1);
            //==================================================================
            //Datos de tabla
            SLStyle es = doc.CreateStyle();
            es.Font.FontSize = 10;
            es.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            es.Font.Bold = true;
            doc.SetCellValue("K6", "Codigo de medicamento");
            doc.MergeWorksheetCells("K6", "L6");
            doc.SetCellStyle("K6", es);

            doc.SetCellValue("M6", "Codigo de venta");
            doc.MergeWorksheetCells("M6", "N6");
            doc.SetCellStyle("M6", es);

            doc.SetCellValue("O6", "Cantidad");
            doc.MergeWorksheetCells("O6", "P6");
            doc.SetCellStyle("O6", es);

            doc.SetCellValue("Q6", "Fecha");
            doc.MergeWorksheetCells("Q6", "R6");
            doc.SetCellStyle("Q6", es);
            doc.MergeWorksheetCells("B5", "I5");

            doc.SetCellValue("S6", "Precio");
            doc.MergeWorksheetCells("S6", "T6");
            doc.SetCellStyle("S6", es);
            doc.MergeWorksheetCells("K5", "T5");
            //=================================================================
            //llenar con datos del grid

            string sql = "select * from DetalleVenta"; int a = 0;
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (a == 0)
                    {
                        doc.SetCellValue("K7", (Convert.ToInt32(dr["idMed"].ToString())));
                        doc.SetCellStyle("K7", es);
                        doc.MergeWorksheetCells("K7", "L7");
                        doc.SetCellValue("M7", (dr["idVen"].ToString()));
                        doc.SetCellStyle("M7", es);
                        doc.MergeWorksheetCells("M7", "N7");
                        doc.SetCellValue("O7", dr["Cantidad"].ToString());
                        doc.SetCellStyle("O7", es);
                        doc.MergeWorksheetCells("O7", "P7");
                        doc.SetCellValue("Q7", dr["Fecha"].ToString());
                        doc.SetCellStyle("Q7", es);
                        doc.MergeWorksheetCells("Q7", "R7");
                        doc.SetCellValue("S7", dr["Precio"].ToString());
                        doc.SetCellStyle("S7", es);
                        doc.MergeWorksheetCells("S7", "T7");


                        a++;
                    }
                    else
                    {
                        doc.SetCellValue("K" + (7 + a) + "", (Convert.ToInt32(dr["idMed"].ToString())));
                        doc.SetCellStyle("K" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("K" + (7 + a) + "", "L" + (7 + a) + "");
                        doc.SetCellValue("M" + (7 + a) + "", (dr["idVen"].ToString()));
                        doc.SetCellStyle("M" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("M" + (7 + a) + "", "N" + (7 + a) + "");
                        doc.SetCellValue("O" + (7 + a) + "", dr["Cantidad"].ToString());
                        doc.SetCellStyle("O" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("O" + (7 + a) + "", "P" + (7 + a) + "");
                        doc.SetCellValue("Q" + (7 + a) + "", dr["Fecha"].ToString());
                        doc.SetCellStyle("Q" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("Q" + (7 + a) + "", "R" + (7 + a) + "");
                        doc.SetCellValue("S" + (7 + a) + "", dr["Precio"].ToString());
                        doc.SetCellStyle("S" + (7 + a) + "", es);
                        doc.MergeWorksheetCells("S" + (7 + a) + "", "T" + (7 + a) + "");
                        a++;
                    }
                }
                dr.Close();
                for (int i = 11; i < 21; i++)
                {
                    for (int j = 2; j < 7 + a; j++)
                    {

                        doc.SetCellStyle(j, i, borde);
                        doc.SetCellStyle(j, i, borde);

                    }
                }
                doc.MergeWorksheetCells("K2", "L4");
                doc.MergeWorksheetCells("S2", "T4");

            }
            con.Close();
            //=================================================================

            doc.SaveAs("Reporte detalle venta.xlsx");
        }
    }
}
