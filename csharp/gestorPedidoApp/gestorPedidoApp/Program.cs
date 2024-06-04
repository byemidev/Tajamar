namespace gestorPedidoApp { 
    
    class Program
    {
        public static void Main(String[] args) {
            
            Conexion conexion = new Conexion();
            Menu menu = new Menu(conexion);
            menu.getMenu();
            conexion.closeConn();   
        }
    }

}