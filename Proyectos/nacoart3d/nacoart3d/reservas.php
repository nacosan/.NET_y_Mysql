<?php


$nombre_local = isset($_POST['nombre']) ? $_POST['nombre'] : '';
$cantidad_local = isset($_POST['cantidad']) ? $_POST['cantidad'] : '';
$categoria_local = isset($_POST['categoria']) ? $_POST['categoria'] : '';
$subcategoria_local = isset($_POST['subcategoria']) ? $_POST['subcategoria'] : '';





?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="apple-touch-icon" href="assets/img/apple-icon.png" />
    <link
      rel="shortcut icon"
      type="image/x-icon"
      href="assets/img/favicon.ico"
    />

    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/templatemo.css" />
    <link rel="stylesheet" href="assets/css/custom.css" />

    <!-- Carga de fuentes después de los estilos -->
    <link
      rel="stylesheet"
      href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;200;300;400;500;700;900&display=swap"
    />
    <link rel="stylesheet" href="assets/css/fontawesome.min.css" />
    <script>
        
    </script>
</head>
<body>
<script>
      const subcategorias = {
        llaveros: ["Coches", "Videojuegos", "NFC"],
        figuras: ["Videojuegos", "Coches", "Anime"],
        utilidades: ["Tazas", "Maceteros", "Cuelga Llaves"],
        otro: ["Diseña tu pieza", "Zona verde"],
      };

      function actualizarSubcategoria() {
        const categoriaSelect = document.getElementById("categoria");
        const subcategoriaSelect = document.getElementById("subcategoria");
        const categoriaSeleccionada = categoriaSelect.value;
        const subcategoriaGuardada = "<?= strtolower(str_replace(' ', '_', $subcategoria_local)) ?>";

        subcategoriaSelect.innerHTML = '<option value="">Seleccione...</option>';
        
        if (categoriaSeleccionada && subcategorias[categoriaSeleccionada]) {
          subcategoriaSelect.disabled = false;
          subcategorias[categoriaSeleccionada].forEach(opcion => {
            const nuevaOpcion = document.createElement("option");
            const valorOpcion = opcion.toLowerCase().replace(/\s+/g, '_');
            nuevaOpcion.value = valorOpcion;
            nuevaOpcion.textContent = opcion;
            
            if (valorOpcion === subcategoriaGuardada) {
              nuevaOpcion.selected = true;
            }
            
            subcategoriaSelect.appendChild(nuevaOpcion);
          });
        } else {
          subcategoriaSelect.disabled = true;
        }
      }

      document.addEventListener("DOMContentLoaded", () => {
        actualizarSubcategoria();
        document.getElementById("categoria").addEventListener("change", actualizarSubcategoria);
      });
      function checkName(nombre) {
  if (nombre.length < 2) {
    alert("Error, tiene que medir más de dos caracteres");
    return false;
  }
  if (!/^[a-zA-Z\s]+$/.test(nombre)) {
    alert("Error, tiene que tener letras y espacios");
    return false;
  }
  return true;
}

document.addEventListener('DOMContentLoaded', function() {
  const nombreInput = document.getElementById('nombre');
  const form = document.querySelector('form');

  nombreInput.addEventListener('blur', function() {
    checkName(this.value);
  });

  form.addEventListener('submit', function(e) {
    if (!checkName(nombreInput.value)) {
      e.preventDefault();
    }
  });
});

      function validarCorreo() {
    const correo = document.getElementById("email").value.trim();
    const dominiosValidos = ["gmail.com", "hotmail.com", "yahoo.com", "outlook.com", "icloud.com"];
    
    if (correo === "") {
        alert("El correo electrónico es obligatorio");
        return false;
    }
    
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(correo)) {
        alert("Formato de correo electrónico inválido");
        return false;
    }
    
    const dominio = correo.split('@')[1];
    if (!dominiosValidos.includes(dominio)) {
        alert("Dominio de correo no permitido. Use: " + dominiosValidos.join(", "));
        return false;
    }
    
    return true;
}

function validarDireccion() {
    const direccion = document.getElementById('direccion').value.trim();
    
    if (direccion.length < 8) {
        alert("Error, la dirección debe tener al menos 8 caracteres");
        return false;
    }
    
    if (!/^[a-zA-Z0-9\s,.-]+$/.test(direccion)) {
        alert("Error, la dirección debe contener solo letras, números, espacios y algunos caracteres especiales (,.-)")
        return false;
    }
    
    return true;
}
      function validarTelefono(){
        if(telefono.length = 9){
            return true;
        }
        else{
            alert("Error, el formato del teléfono no es correcto");
            return false;
        }
      }
      function validarCaptcha() {
  const captchaResultado = document.getElementById("resultado").value;
  if (captchaResultado == 8) {
    return true;
  }
  alert("Captcha incorrecto, prueba otra vez");
  return false;
}

      function validarTerminos() {
  const checkbox = document.getElementById("terminos");
  if (!checkbox.checked) {
    alert("Debes aceptar los términos y condiciones para continuar.");
    return false;
  }
  return true;
}
document.addEventListener('DOMContentLoaded', function() {
  const multicolorRadio = document.getElementById('multicolor');
  const colorBasicRadio = document.getElementById('color-basic');
  const colorOptionsDiv = document.getElementById('color-options');
  const colorCheckboxes = document.querySelectorAll('input[name="colores[]"]');

  function toggleColorOptions() {
    colorOptionsDiv.style.display = multicolorRadio.checked ? 'block' : 'none';
    colorCheckboxes.forEach(checkbox => {
      checkbox.checked = false;
    });
  }

  multicolorRadio.addEventListener('change', toggleColorOptions);
  colorBasicRadio.addEventListener('change', toggleColorOptions);

  colorCheckboxes.forEach(checkbox => {
  checkbox.addEventListener('change', function() {
    const checkedColors = document.querySelectorAll('input[name="colores[]"]:checked');
    if (checkedColors.length > 4) {
      alert('Solo puedes seleccionar hasta 4 colores');
      this.checked = false;
    }
  });
});


document.querySelector('form').addEventListener('submit', function(e) {
  if (multicolorRadio.checked) {
    const checkedColors = document.querySelectorAll('input[name="colores[]"]:checked');
    if (checkedColors.length < 2) {
      e.preventDefault();
      alert('Debes seleccionar al menos 2 colores cuando eliges multicolor');
    } else if (checkedColors.length > 4) {
      e.preventDefault();
      alert('No puedes seleccionar más de 4 colores');
    }
  }
});

});



    </script>
<form action="mailto: pepe@pepe.com" method="POST" class="form-container w-50 mx-auto">
      <input type="hidden" name="id" class="form-input" />
      <label for="nombre">Introduce tu nombre</label>
      <label for="nombre">Introduce tu nombre</label>
<input
  class="form-control mb-2 form-input"
  type="text"
  name="nombre"
  id="nombre"
  value="<?php echo htmlspecialchars($nombre_local); ?>"
  placeholder="Nombre"
  required
/>

      <br />
      <label for="email">Introduce tu email</label>
      <label for="email">Introduce tu email</label>
<input
    class="form-control mb-2 form-input"
    type="email"
    name="email"
    id="email"
    placeholder="Correo electrónico"
    required
>

      <br />
      
      <label for="telefono">Introduce tu móvil</label>

      <input
        class="form-control mb-2"
        type="text"
        name="telefono"
        id="telefono"
        placeholder="Teléfono"
        class="form-input"
      />
      <br />
      <label for="dni">Introduce tu DNI</label>

      <input
        class="form-control mb-2"
        type="text"
        name="dni"
        id="dni"
        placeholder="DNI"
        class="form-input"
      />
      <br />
      <label for="direccion">Introduce tu direccion</label>

      <input
        class="form-control mb-2"
        type="text"
        name="direccion"
        id="direccion"
        placeholder="Direccion"
        class="form-input"
      />

      <br />
      <label for="fecha_entrega">Introduce la fecha que te gustaría recibirlo</label>

      <input
        class="form-control mb-2"
        type="date"
        name="fecha_entrega"
        placeholder="Fecha que quiere su producto"
        class="form-input"
        required
      />
      <br />
      <label for="fecha_entrega">Introduce la fecha que has realizado el pedido del producto</label>

      <input
        class="form-control mb-2"
        type="date"
        name="fecha_actual"
        placeholder="Fecha de hoy"
        class="form-input"
        required
      />
      <br />
      <label for="fecha_entrega">Seleccione una categoría </label>

      <select name="categoria" id="categoria" class="form-select" onchange="actualizarSubcategoria()">
    <option value="">Seleccione...</option>
    <option value="llaveros" <?= ($categoria_local == 'llaveros') ? 'selected' : '' ?>>Llaveros</option>
    <option value="figuras" <?= ($categoria_local == 'figuras') ? 'selected' : '' ?>>Figuras</option>
    <option value="utilidades" <?= ($categoria_local == 'utilidades') ? 'selected' : '' ?>>Utilidades</option>
    <option value="otro" <?= ($categoria_local == 'otro') ? 'selected' : '' ?>>Otro</option>
</select>

      <br />
      <label for="subcategoria" class="form-label"
                >Seleccione la subcategoría
        </label>
        <br>
              <select name="subcategoria" id="subcategoria" class="form-select">
    <option value="">Seleccione...</option>
        </select>
        <br>
        <div>
  <p>Seleccione el tipo de color:</p>
  <div>
    <input type="radio" id="color-basic" name="color" value="color-basic" required />
    <label for="color-basic">Color básico</label>
  </div>
  <div>
    <input type="radio" id="multicolor" name="color" value="multicolor" />
    <label for="multicolor">Multicolor</label>
  </div>
</div>

<div id="color-options" style="display: none;">
  <fieldset>
    <legend>Seleccione de 2 a 4 colores:</legend>
    <div>
      <input type="checkbox" id="blanco" name="colores[]" value="blanco">
      <label for="blanco">Blanco</label>
    </div>
    <div>
      <input type="checkbox" id="negro" name="colores[]" value="negro">
      <label for="negro">Negro</label>
    </div>
    <div>
      <input type="checkbox" id="rojo" name="colores[]" value="rojo">
      <label for="rojo">Rojo</label>
    </div>
    <div>
      <input type="checkbox" id="azul" name="colores[]" value="azul">
      <label for="azul">Azul</label>
    </div>
    <div>
      <input type="checkbox" id="verde" name="colores[]" value="verde">
      <label for="verde">Verde</label>
    </div>
  </fieldset>
</div>


<br>
      <input
        type="text"
        id="captcha"
        name="captcha"
        placeholder="5 + 3"
        readonly
      />
      <input type="number" id="resultado" name="resultado" required />
      <br />
      <div style=" align-items: center">
      <label for="terminos">Acepta los términos y condiciones:
        </label>
        <br>
        <input type="checkbox" id="terminos" name="terminos" required />
        <label for="terminos"
          >He leído y acepto los términos y condiciones.</label
        >
      </div>
      <br />
      <input type="submit" value="Enviar" class="btn btn-primary w-100 mb-2" />
      <a href="index.php" class="btn btn-warning w-100">Volver a inicio</a>
    </form>
</body>
</html>