using AutoMapper;
using backend.DTOs;

namespace backend.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Lookups (tipos)
        CreateMap<TipoMasa, LookupReadDto>();
        CreateMap<TipoRelleno, LookupReadDto>();
        CreateMap<TipoEnvoltura, LookupReadDto>();
        CreateMap<NivelPicante, LookupReadDto>();
        CreateMap<TipoBebida, LookupReadDto>();
        CreateMap<TipoEndulzante, LookupReadDto>();
        CreateMap<TipoTopping, LookupReadDto>();

        CreateMap<LookupCreateUpdateDto, TipoMasa>();
        CreateMap<LookupCreateUpdateDto, TipoRelleno>();
        CreateMap<LookupCreateUpdateDto, TipoEnvoltura>();
        CreateMap<LookupCreateUpdateDto, NivelPicante>();
        CreateMap<LookupCreateUpdateDto, TipoBebida>();
        CreateMap<LookupCreateUpdateDto, TipoEndulzante>();
        CreateMap<LookupCreateUpdateDto, TipoTopping>();

        // Usuarios
        CreateMap<Usuario, UsuarioReadDto>();
        CreateMap<UsuarioCreateDto, Usuario>();
        CreateMap<UsuarioUpdateDto, Usuario>();

        // Sucursales
        CreateMap<Sucursal, SucursalReadDto>();
        CreateMap<SucursalCreateDto, Sucursal>();
        CreateMap<SucursalUpdateDto, Sucursal>();

        // Ingredientes
        CreateMap<Ingrediente, IngredienteReadDto>();
        CreateMap<IngredienteCreateDto, Ingrediente>();
        CreateMap<IngredienteUpdateDto, Ingrediente>();

        // Productos
        CreateMap<Producto, ProductoReadDto>();
        CreateMap<ProductoCreateDto, Producto>();
        CreateMap<ProductoUpdateDto, Producto>();

        // ConfiguracionesProducto
        CreateMap<ConfiguracionProducto, ConfiguracionProductoReadDto>();
        CreateMap<ConfiguracionProductoCreateDto, ConfiguracionProducto>();
        CreateMap<ConfiguracionProductoUpdateDto, ConfiguracionProducto>();

        // Ordenes
        CreateMap<Orden, OrdenReadDto>();
        CreateMap<OrdenCreateDto, Orden>();
        CreateMap<OrdenUpdateDto, Orden>();
    }
}
