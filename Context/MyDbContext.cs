using Microsoft.EntityFrameworkCore;
using Centromedico.Database.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.Context
{
    public partial class MyDbContext : IdentityDbContext
    {
        private string connString;
        public MyDbContext()
        {
        }
        public MyDbContext(string connString)
        {
            this.connString = connString;
        }
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<MyIdentityUser> MyIdentityUsers { get; set; }
        public virtual DbSet<analisis> analisis { get; set; }
        public virtual DbSet<user_info> user_info { get; set; }
        public virtual DbSet<analisis_categoria> analisis_categoria { get; set; }
        public virtual DbSet<balance_caja> balance_caja { get; set; }
        public virtual DbSet<citas> citas { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<cobertura_analisis> cobertura_analisis { get; set; }
        public virtual DbSet<cobertura_medicos> cobertura_medicos { get; set; }
        public virtual DbSet<cod_verificacion> cod_verificacion { get; set; }
        public virtual DbSet<especialidades> especialidades { get; set; }
        public virtual DbSet<especialidades_medicos> especialidades_medicos { get; set; }
        public virtual DbSet<extensiones_telefonicas> extensiones_telefonicas { get; set; }
        public virtual DbSet<horarios_analisis> horarios_analisis { get; set; }
        public virtual DbSet<horarios_medicos> horarios_medicos { get; set; }
        public virtual DbSet<horarios_medicos_reservados> horarios_medicos_reservados { get; set; }
        public virtual DbSet<medicos> medicos { get; set; }
        public virtual DbSet<noticias> noticias { get; set; }
        public virtual DbSet<pacientes> pacientes { get; set; }
        public virtual DbSet<pruebas> pruebas { get; set; }
        public virtual DbSet<resultados> resultados { get; set; }
        public virtual DbSet<secretarias> secretarias { get; set; }
        public virtual DbSet<secretarias_medicos> secretarias_medicos { get; set; }
        public virtual DbSet<seguros> seguros { get; set; }
        public virtual DbSet<servicios> servicios { get; set; }
        public virtual DbSet<servicios_medicos> servicios_medicos { get; set; }
        public virtual DbSet<token> token { get; set; }
        public virtual DbSet<turnos> turnos { get; set; }
        public virtual DbSet<dias_feriados> dias_feriados { get; set; }
        public virtual DbSet<grupo_doctor_secretaria> grupo_doctor_secretaria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");



            modelBuilder.Entity<MyIdentityUser>(entity =>
            {


                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

            });




            modelBuilder.Entity<grupo_doctor_secretaria>(entity =>
            {

               /* entity.Property(e => e.MyIdentityUserID)
                    .IsRequired()
                    .HasMaxLength(450);
               */
                entity.Property(e => e.group_name)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.type)
                .IsRequired()
                .HasMaxLength(50);


                entity.HasOne(d => d.medicos)
                    .WithMany(p => p.grupo_doctor_secretaria)
                    .HasForeignKey(d => d.medicosID)
                    .HasConstraintName("FK_grupo_medicos");

               /* entity.HasOne(d => d.MyIdentityUsers)
                    .WithMany(p => p.grupo_doctor_secretaria)
                    .HasForeignKey(d => d.MyIdentityUserID)
                    .HasConstraintName("FK_grupo_users");
            */});

            modelBuilder.Entity<analisis>(entity =>
            {
                entity.HasOne(d => d.analisis_categoria)
                    .WithMany(p => p.analisis)
                    .HasForeignKey(d => d.analisis_categoriaID)
                    .HasConstraintName("FK_analisis_analisiscategoria");
            });

            modelBuilder.Entity<analisis_categoria>(entity =>
            {
                entity.Property(e => e.descrip).IsFixedLength(true);

                entity.Property(e => e.estados).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<balance_caja>(entity =>
            {
                entity.HasKey(e => new { e.ID })
                    .HasName("PK_Id");

                entity.HasComment("esto es metadato, en caso de que se elimine a la secretaria");

                entity.Property(e => e.fecha).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.balance_inicial).HasDefaultValueSql("((0))");

                entity.Property(e => e.secretaria_nombre).IsFixedLength(true);

                entity.HasOne(d => d.medicos)
                    .WithMany(p => p.balance_caja)
                    .HasForeignKey(d => d.medicosID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_balanceCaja_medicos");

                entity.HasOne(d => d.secretarias)
                    .WithMany(p => p.balance_caja)
                    .HasForeignKey(d => d.secretariasID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_balanceCaja_secretarias");
            });

            modelBuilder.Entity<citas>(entity =>
            {
                entity.Property(e => e.cobertura).HasDefaultValueSql("((0))");

                entity.Property(e => e.cod_verificacionID).IsFixedLength(true);

                entity.Property(e => e.contacto).IsFixedLength(true);

                entity.Property(e => e.contacto_whatsapp).HasDefaultValueSql("((0))");

                entity.Property(e => e.deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.segurosID).HasComment("NULL por defecto es sin seguro");


                /*   entity.HasOne(d => d.especialidades)
                       .WithMany(p => p.citas)
                       .HasForeignKey(d => d.especialidadesID)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_citas_especialidades");*/

                entity.HasOne(d => d.medicos)
                    .WithMany(p => p.citas)
                    .HasForeignKey(d => d.medicosID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_citas_medicos");

                entity.HasOne(d => d.pacientes)
                    .WithMany(p => p.citas)
                    .HasForeignKey(d => d.pacientesID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_citas_pacientes");

                entity.HasOne(d => d.secretarias)
                    .WithMany(p => p.citas)
                    .HasForeignKey(d => d.secretariasID)
                    .HasConstraintName("FK_citas_secretarias");

                entity.HasOne(d => d.seguros)
                    .WithMany(p => p.citas)
                    .HasForeignKey(d => d.segurosID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_citas_seguros");

                entity.HasOne(d => d.servicios)
                    .WithMany(p => p.citas)
                    .HasForeignKey(d => d.serviciosID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_citas_servicios");

            });

            modelBuilder.Entity<clientes>(entity =>
            {
                entity.Property(e => e.apellido).IsFixedLength(true);

                entity.Property(e => e.doc_identidad).IsFixedLength(true);

                entity.Property(e => e.nombre).IsFixedLength(true);

                entity.HasOne(d => d.MyIdentityUsers)
                    .WithMany(p => p.clientes)
                    .HasForeignKey(d => d.MyIdentityUserID)
                    .HasConstraintName("FK_clientes_MyIdentityUsers");
            });

            modelBuilder.Entity<cobertura_analisis>(entity =>
            {
                entity.HasKey(e => new { e.analisisID, e.segurosID })
                    .HasName("PK__cobertur__CD52B54228276F07");

                entity.HasOne(d => d.analisis)
                    .WithMany(p => p.cobertura_analisis)
                    .HasForeignKey(d => d.analisisID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_coberturaAnalisis_analisis");

                entity.HasOne(d => d.seguros)
                    .WithMany(p => p.cobertura_analisis)
                    .HasForeignKey(d => d.segurosID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_coberturaAnalisis_seguros");
            });

            modelBuilder.Entity<cobertura_medicos>(entity =>
            {
                entity.HasKey(e => new { e.medicosID, e.segurosID })
                    .HasName("PK__cobertur__74EF980EA71F387B");

                entity.HasOne(d => d.medicos)
                    .WithMany(p => p.cobertura_medicos)
                    .HasForeignKey(d => d.medicosID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_coberturaMedicos_medicos");

                entity.HasOne(d => d.seguros)
                    .WithMany(p => p.cobertura_medicos)
                    .HasForeignKey(d => d.segurosID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_coberturaMedicos_seguros");

                /*    entity.HasOne(d => d.especialidades)
                        .WithMany(p => p.cobertura_medicos)
                        .HasForeignKey(d => d.especialidadesID)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_coberturaMedicos_especialidades");*/
            });


            modelBuilder.Entity<user_info>(entity =>
            {
                entity.HasKey(e => new { e.doc_identidad })
                    .HasName("pk_user_info");
                entity.HasCheckConstraint("ck_sexo", "Sexo debe de ser m o f");


            });


            modelBuilder.Entity<especialidades>(entity =>
            {
                entity.Property(e => e.estado).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<especialidades_medicos>(entity =>
            {
                entity.HasKey(e => new { e.especialidadesID, e.medicosID })
                    .HasName("PK__especial__5054F577EDA07E29");

                entity.HasOne(d => d.especialidades)
                    .WithMany(p => p.especialidades_medicos)
                    .HasForeignKey(d => d.especialidadesID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_especialidadesMedicos_especialidades");

                entity.HasOne(d => d.medicos)
                    .WithMany(p => p.especialidades_medicos)
                    .HasForeignKey(d => d.medicosID)
                    .HasConstraintName("FK_especialidadesMedicos_medicos");
            });

            modelBuilder.Entity<cod_verificacion>(entity =>
            {
                entity.HasKey(e => new { e.value, e.citasID })
                    .HasName("PK__cod_verifi__citasID_Value");

                entity.HasOne(d => d.citas)
                      .WithMany(p => p.cod_verificacion)
                    .HasForeignKey(d => d.citasID)
                    .HasConstraintName("FK_codVerificacion_citas")
                    .OnDelete(DeleteBehavior.ClientCascade);

            });


            modelBuilder.Entity<extensiones_telefonicas>(entity =>
            {
                entity.Property(e => e.ID).IsFixedLength(true);

                entity.HasOne(d => d.medicos)
                    .WithMany(p => p.extensiones_telefonicas)
                    .HasForeignKey(d => d.medicosID)
                    .HasConstraintName("FK_extensiones_telefonicas_medicos");
            });









            modelBuilder.Entity<horarios_analisis>(entity =>
            {
                entity.HasKey(e => e.analisisID);

                entity.Property(e => e.analisisID).ValueGeneratedNever();

                entity.HasOne(d => d.analisis)
                     .WithOne(p => p.horarios_analisis)
                     .HasForeignKey<horarios_analisis>(d => d.analisisID)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_horariosAnalisis_analisis");

                entity.Property(e => e.friday_from).HasColumnType("time(4)");

                entity.Property(e => e.friday_until).HasColumnType("time(4)");

                entity.Property(e => e.monday_from).HasColumnType("time(4)");

                entity.Property(e => e.monday_until).HasColumnType("time(4)");

                entity.Property(e => e.saturday_from).HasColumnType("time(4)");

                entity.Property(e => e.saturday_until).HasColumnType("time(4)");

                entity.Property(e => e.sunday_from).HasColumnType("time(4)");

                entity.Property(e => e.sunday_until).HasColumnType("time(4)");

                entity.Property(e => e.thursday_from).HasColumnType("time(4)");

                entity.Property(e => e.thursday_until).HasColumnType("time(4)");

                entity.Property(e => e.tuesday_from).HasColumnType("time(4)");

                entity.Property(e => e.tuesday_until).HasColumnType("time(4)");

                entity.Property(e => e.wednesday_from).HasColumnType("time(4)");

                entity.Property(e => e.wednesday_until).HasColumnType("time(4)");
            });

            modelBuilder.Entity<horarios_medicos>(entity =>
            {
                entity.HasKey(e => e.medicosID);

                entity.HasOne(d => d.medicos)
                     .WithOne(p => p.horarios_medicos)
                     .HasForeignKey<horarios_medicos>(d => d.medicosID)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_horariosAnalisis_medicos");

                entity.Property(e => e.medicosID).ValueGeneratedNever();

                entity.Property(e => e.friday_from).HasColumnType("time(4)");

                entity.Property(e => e.friday_until).HasColumnType("time(4)");

                entity.Property(e => e.monday_from).HasColumnType("time(4)");

                entity.Property(e => e.monday_until).HasColumnType("time(4)");

                entity.Property(e => e.saturday_from).HasColumnType("time(4)");

                entity.Property(e => e.saturday_until).HasColumnType("time(4)");

                entity.Property(e => e.sunday_from).HasColumnType("time(4)");

                entity.Property(e => e.sunday_until).HasColumnType("time(4)");

                entity.Property(e => e.thursday_from).HasColumnType("time(4)");

                entity.Property(e => e.thursday_until).HasColumnType("time(4)");

                entity.Property(e => e.tiempo_cita).HasColumnType("time(4)");

                entity.Property(e => e.tuesday_from).HasColumnType("time(4)");

                entity.Property(e => e.tuesday_until).HasColumnType("time(4)");

                entity.Property(e => e.wednesday_from).HasColumnType("time(4)");

                entity.Property(e => e.wednesday_until).HasColumnType("time(4)");

                entity.Property(e => e.free_time_from).HasColumnType("time(4)");

                entity.Property(e => e.free_time_until).HasColumnType("time(4)");
            });

            modelBuilder.Entity<horarios_medicos_reservados>(entity =>
            {
                entity.HasKey(e => new { e.fecha_hora, e.medicosID })
                    .HasName("PK__horarios__F4FFBE305C750D59");

                entity.Property(e => e.fecha_hora).HasColumnType("datetime");

            });


            /*        modelBuilder.Entity<horarios_analisis>(entity =>
                        {
                            entity.Property(e => e.analisisID).ValueGeneratedNever();

               *//*             entity.HasOne(d => d.analisis)
                                .WithOne(p => p.horarios_analisis)
                                .HasForeignKey<horarios_analisis>(d => d.analisisID)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_horariosAnalisis_analisis");*//*
                        });

                        modelBuilder.Entity<horarios_medicos>(entity =>
                        {
                            entity.Property(e => e.medicosID).ValueGeneratedNever();

                           *//* entity.HasOne(d => d.medicos)
                                .WithOne(p => p.horarios_medicos)
                                .HasForeignKey<horarios_medicos>(d => d.medicosID)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_horariosAnalisis_medicos");*//*
                        });
            */
            modelBuilder.Entity<medicos>(entity =>
            {
                entity.HasComment("m o f");

                entity.Property(e => e.apellido).IsFixedLength(true);

                entity.Property(e => e.cedula).IsFixedLength(true);

                entity.Property(e => e.colegiatura).IsFixedLength(true);

                entity.Property(e => e.estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.exequatur).IsFixedLength(true);

                entity.Property(e => e.fecha_creacion).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.nombre).IsFixedLength(true);

                entity.Property(e => e.sexo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.telefono1).IsFixedLength(true);

                entity.Property(e => e.telefono2).IsFixedLength(true);

                entity.HasOne(d => d.MyIdentityUsers)
                    .WithMany(p => p.medicos)
                    .HasForeignKey(d => d.MyIdentityUserID)
                    .HasConstraintName("FK_medicos_MyUserID");
            });

            modelBuilder.Entity<noticias>(entity =>
            {
                entity.Property(e => e.estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.fecha_creacion).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.lugar).IsFixedLength(true);
            });

            modelBuilder.Entity<pacientes>(entity =>
            {
                entity.Property(e => e.apellido).IsFixedLength(true);

                entity.Property(e => e.apellido_tutor).IsFixedLength(true);

                entity.Property(e => e.doc_identidad).IsFixedLength(true);

                entity.Property(e => e.doc_identidad_tutor).IsFixedLength(true);

                entity.Property(e => e.nombre).IsFixedLength(true);

                entity.Property(e => e.nombre_tutor).IsFixedLength(true);

                entity.Property(e => e.sexo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.contacto)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MyIdentityUsers)
               .WithMany(p => p.pacientes)
               .HasForeignKey(d => d.MyIdentityUserID)
               .HasConstraintName("FK_pacientes_MyIdentityUsers");
            });

            modelBuilder.Entity<pruebas>(entity =>
            {
                entity.Property(e => e.fecha_emision).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.nota).IsFixedLength(true);

                entity.HasOne(d => d.analisis)
                    .WithMany(p => p.pruebas)
                    .HasForeignKey(d => d.analisisID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pruebas_analisis");

                entity.HasOne(d => d.resultados)
                    .WithMany(p => p.pruebas)
                    .HasForeignKey(d => d.resultadosID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pruebas_resultados");
            });

            modelBuilder.Entity<resultados>(entity =>
            {
                entity.Property(e => e.fecha_entrada).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.clientes)
                    .WithMany(p => p.resultados)
                    .HasForeignKey(d => d.clientesID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_resultados_clientes");

                entity.HasOne(d => d.medicos)
                    .WithMany(p => p.resultados)
                    .HasForeignKey(d => d.medicosID)
                    .HasConstraintName("FK_resultados_medicos");
            });

            modelBuilder.Entity<secretarias>(entity =>
            {
                entity.Property(e => e.apellido).IsFixedLength(true);

                entity.Property(e => e.correo).IsFixedLength(true);

                entity.Property(e => e.estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.fecha_creacion).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.nombre).IsFixedLength(true);

                entity.HasOne(d => d.MyIdentityUsers)
                    .WithMany(p => p.secretarias)
                    .HasForeignKey(d => d.MyIdentityUserID)
                    .HasConstraintName("FK_secretarias_MyUserID");
            });

            modelBuilder.Entity<secretarias_medicos>(entity =>
            {
                entity.HasKey(e => new { e.medicosID, e.secretariasID })
                    .HasName("PK__secretar__9616A70817FD4605");

                entity.HasOne(d => d.medicos)
                    .WithMany(p => p.secretarias_medicos)
                    .HasForeignKey(d => d.medicosID)
                    .HasConstraintName("FK_secretariasMedicos_medicos");

                entity.HasOne(d => d.secretarias)
                    .WithMany(p => p.secretarias_medicos)
                    .HasForeignKey(d => d.secretariasID)
                    .HasConstraintName("FK_secretariasMedicos_secretarias");
            });

            modelBuilder.Entity<seguros>(entity =>
            {
                entity.Property(e => e.descrip).IsFixedLength(true);
            });

            modelBuilder.Entity<servicios>(entity =>
            {
                entity.Property(e => e.descrip).IsFixedLength(true);
            });

            modelBuilder.Entity<servicios_medicos>(entity =>
            {
                entity.HasKey(e => new { e.medicosID, e.serviciosID })
                    .HasName("PK__servicio__E9179B87333BE270");

                entity.HasOne(d => d.servicios)
                    .WithMany(p => p.servicios_medicos)
                    .HasForeignKey(d => d.serviciosID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_serviciosMedicos_servicios");
            });

            modelBuilder.Entity<token>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.tokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TokenModel_AspNetUsers_UserId");
            });

            modelBuilder.Entity<turnos>(entity =>
            {
                entity.Property(e => e.medicosID).ValueGeneratedNever();

                entity.HasOne(d => d.medicos)
                    .WithOne(p => p.turnos)
                    .HasForeignKey<turnos>(d => d.medicosID)
                    .HasConstraintName("FK_turnos_medicos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
