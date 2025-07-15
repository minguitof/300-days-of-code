from PIL import Image

def convertir_imagen_a_ascii(ruta_imagen, ancho_salida=100):
    """
    Converts a given image to ASCII art.
    """
    try:
        imagen = Image.open(ruta_imagen)
    except FileNotFoundError:
        print(f"Error: La imagen en la ruta '{ruta_imagen}' no fue encontrada.")
        return None
    except Exception as e:
        print(f"Error al abrir la imagen: {e}")
        return None

    imagen = imagen.convert("L")

    ancho_original, alto_original = imagen.size
    relacion_aspecto = alto_original / ancho_original
    alto_salida = int(ancho_salida * relacion_aspecto * 0.55) 
    imagen = imagen.resize((ancho_salida, alto_salida))

    ascii_chars = "#W$@%*+=-. " # Puedes cambiar a la línea de arriba para más detalle

    pixels = imagen.getdata()
    ascii_art = ""
    for pixel_value in pixels:
        index = int(pixel_value / 255 * (len(ascii_chars) - 1))
        ascii_art += ascii_chars[index]

    ascii_lines = [ascii_art[i:i + ancho_salida] for i in range(0, len(ascii_art), ancho_salida)]
    
    return "\n".join(ascii_lines)

def generar_svg_con_info(ascii_art_string, info_sections, output_filename="readme_profile.svg", 
                         bg_color="#161b22", text_color="#c9d1d9", 
                         key_color="#ffa657", value_color="#a5d6ff", font_size=16):
    """
    Generates an SVG file with ASCII art on the left and profile data on the right.
    """
    ascii_lines = ascii_art_string.split('\n')
    
    char_width_px = 9.6 
    line_height_factor = 1.2 

    # --- SVG Dimensions ---
    ascii_max_width_chars = max(len(line) for line in ascii_lines)
    ascii_panel_width = int(ascii_max_width_chars * char_width_px) + 30 
    
    info_panel_base_width = 650 # Aumentado ligeramente de 550 a 580
    
    info_total_lines = 0
    if info_sections and info_sections[0].get("title") == "username_header":
        info_total_lines += 2 # For username and separator
        
    for section in info_sections:
        if section.get("title") and section["title"] != "username_header":
            info_total_lines += 2 # For section title + separator
        info_total_lines += len(section.get('items', []))
        if section.get('extra_line_after', False): 
            info_total_lines += 1 # Ensure enough lines for spacing

    info_height = info_total_lines * font_size * line_height_factor
    
    # INCREASE THIS PADDING TO GIVE MORE VERTICAL SPACE TO THE SVG
    svg_height = int(max(len(ascii_lines) * font_size * line_height_factor, info_height)) + 80 # Aumentado de 60 a 80
    svg_width = ascii_panel_width + info_panel_base_width + 30 

    icon_map = {
        "Nombre": "💻", "Edad": "🎂", "Ubicación": "📍", "Intereses": "💡",
        "Lenguajes de Programación": "🧠", "Tecnologías Web": "🌐", 
        "Bases de Datos": "💾", "Herramientas DevOps": "🛠️",
        "Hobbies": "🎮", 
        "Email": "📧", "LinkedIn": "🔗", "Twitter": "🐦", "Discord": "💬",
        "Total Repositorios": "📦", "Estrellas Totales": "⭐", 
        "Forks Totales": "🍴", "Total Commits": "⚡", 
        "Seguidores": "👥", "Líneas de Código (LOC)": "📈",
        "Stack": "🧠" 
    }

    svg_content = f"""<?xml version='1.0' encoding='UTF-8'?>
<svg xmlns="http://www.w3.org/2000/svg" font-family="ConsolasFallback,Consolas,monospace" width="{svg_width}px" height="{svg_height}px" font-size="{font_size}px">
<style>
@font-face {{
  src: local('Consolas'), local('Consolas Bold');
  font-family: 'ConsolasFallback';
  font-display: swap;
  -webkit-size-adjust: 109%;
  size-adjust: 109%;
}}
.key {{fill: {key_color};}}
.value {{fill: {value_color};}}
.header-line {{fill: {text_color};}}
.section-title {{fill: {key_color}; font-weight: bold;}}
text, tspan {{white-space: pre;}}
</style>
<rect width="100%" height="100%" fill="{bg_color}"/>

<g id="ascii-panel">
<text fill="{text_color}">
"""
    ascii_start_y = (svg_height - (len(ascii_lines) * font_size * line_height_factor)) / 2 + font_size 

    for i, line in enumerate(ascii_lines):
        x_pos = 15 + (ascii_panel_width - (len(line) * char_width_px)) / 2 
        y_pos = ascii_start_y + (i * font_size * line_height_factor)
        svg_content += f'<tspan x="{x_pos}" y="{y_pos}">{line}</tspan>\n'

    svg_content += """</text>
</g> <g id="info-panel">
"""
    info_panel_start_y = (svg_height - info_height) / 2 + font_size

    info_x_start = ascii_panel_width + 15
    current_y = info_panel_start_y 

    # Start the actual text element for the info panel inside its group
    svg_content += f"""<text x="{info_x_start}" y="{info_panel_start_y}" fill="{text_color}">"""

    for section in info_sections:
        if section.get("title") == "username_header":
            # Handle username and initial separator
            svg_content += f'<tspan x="{info_x_start}" y="{current_y}">{section["username"]}</tspan>\n'
            current_y += font_size * line_height_factor
            svg_content += f'<tspan x="{info_x_start}" y="{current_y}">{"-" * 45}</tspan>\n' 
            current_y += font_size * line_height_factor * 1.2 
        elif section.get("title"):
            # Handle section title
            svg_content += f'<tspan x="{info_x_start}" y="{current_y}" class="section-title">- {section["title"]}</tspan>\n'
            current_y += font_size * line_height_factor
            svg_content += f'<tspan x="{info_x_start}" y="{current_y}">{"-" * 45}</tspan>\n' 
            current_y += font_size * line_height_factor * 1.2 

        for item_key, item_value in section.get('items', []):
            icon = icon_map.get(item_key, "") + " " 
            
            # These items will print key and value without dots, allowing value to flow
            if item_key in ["Stack", "Lenguajes de Programación", "Tecnologías Web", 
                            "Bases de Datos", "Herramientas DevOps", "Hobbies",
                            "Email", "LinkedIn", "Twitter", "Discord"]:
                svg_content += f'<tspan x="{info_x_start}" y="{current_y}" class="key">{icon}{item_key}: </tspan>'
                svg_content += f'<tspan class="value">{str(item_value)}</tspan>\n'
            elif item_key == "Líneas de Código (LOC)":
                # Special handling for LOC with colored parts
                parts = str(item_value).split(" ", 1) 
                total_loc = parts[0]
                details_loc = parts[1] if len(parts) > 1 else ""

                svg_content += f'<tspan x="{info_x_start}" y="{current_y}" class="key">{icon}{item_key}: </tspan>'
                svg_content += f'<tspan class="value">{total_loc}</tspan>'
                
                if details_loc:
                    add_part = ""
                    del_part = ""
                    
                    # More robust parsing for (+add, -del)
                    details_stripped = details_loc.replace('(', '').replace(')', '').strip()
                    parts_inner = [p.strip() for p in details_stripped.split(',')]
                    
                    for p in parts_inner:
                        if p.startswith('+'):
                            add_part = p
                        elif p.startswith('-'):
                            del_part = p

                    svg_content += f'<tspan class="value"> (</tspan>'
                    if add_part:
                        svg_content += f'<tspan fill="#3fb950">{add_part}</tspan>'
                    if add_part and del_part:
                        svg_content += f'<tspan class="value">,</tspan><tspan> </tspan>'
                    if del_part:
                        svg_content += f'<tspan fill="#f85149">{del_part}</tspan>'
                    svg_content += f'<tspan class="value">)</tspan>'

                svg_content += '\n'
            else: # For short, standard key-value pairs with dots
                key_display = f"{icon}{item_key}: "
                
                total_display_width_chars = 28 
                key_display_chars = len(key_display)

                dots_needed_count = max(0, total_display_width_chars - key_display_chars) 
                dots = "." * dots_needed_count

                svg_content += f'<tspan x="{info_x_start}" y="{current_y}" class="key">{key_display}{dots}</tspan>'
                svg_content += f'<tspan class="value">{str(item_value)}</tspan>\n'
            
            current_y += font_size * line_height_factor

        if section.get('extra_line_after', False):
            current_y += font_size * line_height_factor * 0.5 

    svg_content += """</text>
</g> </svg>"""

    with open(output_filename, "w", encoding="utf-8") as f:
        f.write(svg_content)

# --- SCRIPT USAGE ---
if __name__ == "__main__":
    ruta_de_tu_foto = "unnamed3.jpg" 
    ancho_deseado_ascii = 50

    mis_datos_secciones = [
        {
            "title": "username_header",
            "username": "M4r10@github",
            "items": [
                ("Nombre", "M4r10"),
                ("Edad", "24 años"),
                ("Ubicación", "Itagüí, Colombia"),
                ("Intereses", "Desarrollo web, Backend, IA, Videojuegos"),
            ],
            "extra_line_after": True
        },
        {
            "title": "Stack",
            "items": [
                ("Stack", "Python, JS, .NET Core, C#, GitHub Actions"),
                ("Lenguajes de Programación", "JavaScript, C#"),
                ("Tecnologías Web", "HTML, CSS, Vue.js, Node.js"), 
                ("Bases de Datos", "PostgreSQL, MySQL"), 
                ("Herramientas DevOps", "GitHub Actions"),
            ],
            "extra_line_after": True
        },
        {
            "title": "Hobbies",
            "items": [
                ("Hobbies", "Lectura, Gimnasio"),
            ],
            "extra_line_after": True
        },
        {
            "title": "Contacto",
            "items": [
                ("Email", "tu.email@ejemplo.com"),
                ("LinkedIn", "tu_usuario_linkedin"),
                ("Twitter", "tu_usuario_twitter"),
                ("Discord", "tu_usuario_discord"),
            ],
            "extra_line_after": True
        },
        {
            "title": "GitHub Stats",
            "items": [
                ("Total Repositorios", 10),
                ("Estrellas Totales", 0),
                ("Forks Totales", 0),
                ("Total Commits", 27),
                ("Seguidores", 5),
                ("Líneas de Código (LOC)", "446,276 (+523,178, -76,902)"), 
            ],
            "extra_line_after": False
        }
    ]

    bg_color = "#161b22" 
    text_color = "#c9d1d9" 
    key_color = "#ffa657"   
    value_color = "#a5d6ff"   
    
    print(f"Generando SVG de perfil para: {ruta_de_tu_foto}...")
    
    ascii_result = convertir_imagen_a_ascii(ruta_de_tu_foto, ancho_salida=ancho_deseado_ascii)

    if ascii_result:
        svg_filename = "mi_perfil_readme.svg"
        generar_svg_con_info(ascii_result, 
                             mis_datos_secciones,
                             output_filename=svg_filename,
                             bg_color=bg_color,
                             text_color=text_color,
                             key_color=key_color,   
                             value_color=value_color) 
        
        print(f"\n¡SVG de perfil generado como '{svg_filename}'!")
        print(f"Para usarlo en tu README.md, añade la línea:\n\n`![Mi Perfil GitHub](/{svg_filename})`\n")
        print("Asegúrate de que el archivo SVG esté en la misma carpeta que tu README.md, o ajusta la ruta.")
    else:
        print("\nNo se pudo generar el arte ASCII para el SVG.")