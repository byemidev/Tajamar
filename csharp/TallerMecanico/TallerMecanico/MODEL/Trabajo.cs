

namespace TallerMecanico.MODEL
{
    public interface Trabajo
    {
        void modificarHorasTrabajo(int horas, Trabajo_impl trabajo);
        int getTrabajoId(List<Trabajo_impl> trabajos);

        void finalizarTrabajo(Trabajo_impl trabajo);
    }
}
