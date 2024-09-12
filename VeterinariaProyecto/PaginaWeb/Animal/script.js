function cargarAnimales() {
    fetch('https://localhost:7275/api/animal', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }
    })
    .then(response => response.json())
    .then(data => {
        const tableBody = document.getElementById('animal-table-body');
        tableBody.innerHTML = ''; 

        // Itera sobre los animales y los agrega como filas en la tabla
        data.forEach(animal => {
            const row = document.createElement('tr');

            row.innerHTML = `
                <td>${animal.id}</td>
                <td>${animal.nombre}</td>
                <td>${animal.duenio}</td>
                <td>
                    <a class="btn btn-sm btn-primary" href="/Animal/editar.html?id=${animal.id}">Editar</a>
                    <a class="btn btn-sm btn-secondary" href="/Animal/detalle.html?id=${animal.id}">Detalle</a>
                    <a class="btn btn-sm btn-danger" href="/Animal/eliminar.html?id=${animal.id}">Eliminar</a>
                </td>
            `;

            // Agrega la fila al cuerpo de la tabla
            tableBody.appendChild(row)
        });
    })
    .catch((error) => {
        alert('Error al obtener los animales:', error)
    });
}

function GetUrlParamId(){
    const queryString = window.location.search
    const urlParams = new URLSearchParams(queryString)

    return urlParams.get('id')
}

function CargarDetalleAnimal(){
    const id = GetUrlParamId();    

    fetch(`https://localhost:7275/api/animal/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }
    })
    .then(response => response.json())
    .then(data =>{
        const cuerpoDetalle = document.getElementById('cuerpo-detalle')

        cuerpoDetalle.innerHTML = ''; 

        cuerpoDetalle.innerHTML = `
            <p>Id: ${data.id}</p>
            <p>Nombre: ${data.nombre}</p>
            <p>Raza: ${data.raza}</p>
            <p>Sexo: ${data.sexo}</p>
            <p>Edad: ${data.edad}</p>
            <p>Dueño: ${data.duenio}</p>
        `
    })
    .catch((error) =>{
        alert('Error al obtener el detalle: ' + error)
    })
    
}

function EliminarAnimal(){
    const id = GetUrlParamId();

    fetch(`https://localhost:7275/api/animal/${id}`, {
        method: 'DELETE',
    })
    .then(response => response.json())
    .then(data => console.log(data)) 
    .catch(error => console.log("Error al eliminar el animal: " + error)) 

    window.location.href = '/Animal/listado.html';
}

function CargarCampos(){
    const id = GetUrlParamId();

    fetch(`https://localhost:7275/api/animal/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }
    })
    .then(response => response.json())
    .then(data => {
        document.getElementById('input-nombre').value = data.nombre
        document.getElementById('input-raza').value = data.raza
        document.getElementById('input-sexo').value = data.sexo
        document.getElementById('input-edad').value = data.edad
        document.getElementById('input-duenio').value = data.duenioId
    })
}

function RegistrarAnimal(){
    const nombre = document.getElementById('input-nombre').value
    const raza = document.getElementById('input-raza').value
    const sexo = document.getElementById('input-sexo').value
    const edad = document.getElementById('input-edad').value
    const duenioId = document.getElementById('input-duenio').value

    const dataAnimal = {
        nombre: nombre,
        raza:  raza,
        sexo: sexo,
        edad: edad,
        duenioId: duenioId
    }

    fetch(`https://localhost:7275/api/animal/`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(dataAnimal)
    })
    .then(response => response.json())
    .then(data =>{
        console.alert('Éxito al registrar el animal.');
    }).catch((error) =>{
        console.alert('Error al obtener el detalle: ' + error)
    })

}

function EditarAnimal(){
    const id = GetUrlParamId()
    const nombre = document.getElementById('input-nombre').value
    const raza = document.getElementById('input-raza').value
    const sexo = document.getElementById('input-sexo').value
    const edad = document.getElementById('input-edad').value
    const duenioId = document.getElementById('input-duenio').value

    const dataAnimal = {
        nombre: nombre,
        raza:  raza,
        sexo: sexo,
        edad: edad,
        duenioId: duenioId
    }

    fetch(`https://localhost:7275/api/animal/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(dataAnimal)
    })
    .then(response => response.json())
    .then(data =>{
        console.log('Éxito al registrar el animal.' + data);
    }).catch((error) =>{
        console.log('Error al obtener el detalle: ' + error)
    })

    window.location.href = '/Animal/listado.html';
}

function FormRegistro(){
    const form = document.getElementById('animal-form')

    form.addEventListener("submit", (event) => {
        event.preventDefault();
        RegistrarAnimal();
      });
}

function FormEditar(){
    CargarCampos();
    const form = document.getElementById('animal-form')

    form.addEventListener("submit", (event) => {
        event.preventDefault();
        EditarAnimal();
      }); 
}