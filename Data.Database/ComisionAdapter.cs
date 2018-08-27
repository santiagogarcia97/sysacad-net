﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database {
    public class ComisionAdapter : Adapter {
        public List<Comision> GetAll() {
            List<Comision> comisiones = new List<Comision>();
            try {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones", SqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read()) {
                    Comision com = new Comision();

                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                    com.IDString = (com.ID.ToString() + " - " + com.Descripcion);
                    comisiones.Add(com);
                }
                drComisiones.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return comisiones;
        }
        public Comision GetOne(int ID) {
            Comision com = new Comision();
            try {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@id", SqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read()) {
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                    com.IDString = (com.ID.ToString() + " - " + com.Descripcion);

                }
                drComisiones.Close();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
            return com;
        }
        public void Delete(int ID) {
            try {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Exception excepcionManejada = new Exception("Error al eliminar comision", ex);
                throw excepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }
        protected void Update(Comision com) {
            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET id_plan = @idplan, " +
                    "desc_comision = @desc, anio_especialidad = @anio " +
                    "WHERE id_comision=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = com.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("@idplan", SqlDbType.Int).Value = com.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de comision", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }
        protected void Insert(Comision com) {

            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO comisiones(desc_comision, anio_especialidad, id_plan) " +
                    "values(@desc, @anio, @idplan) SELECT @@identity", SqlConn);
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("@idplan", SqlDbType.Int).Value = com.IDPlan;
                com.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }
        }
        public void Save(Comision com) {
            if (com.State == BusinessEntity.States.Deleted) {
                this.Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.New) {
                this.Insert(com);
            }
            else if (com.State == BusinessEntity.States.Modified) {
                this.Update(com);
            }
            com.State = BusinessEntity.States.Unmodified;
        }


    }
}
