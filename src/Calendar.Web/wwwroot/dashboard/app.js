var app = new Vue({
  el: '#app',
  data:
  {
    userSerials: null
  },
  mounted() {
    API.getUserSerials().then((data) => {
      this.userSerials = data;
    });
  },
   methods: {
    addUserSerial: function(serial) {
      this.userSerials.push(serial);
      API.addUserSerial(serial);
    },
    removeUserSerial: function(serial) {      
      this.userSerials = this.userSerials.filter((s) => s !== serial);
      API.removeUserSerial(serial);
    }
   },  
  template: `
  <div class="container">
  <div class="py-5 text-center">
        <h2>Settings</h2>    
      </div>      
      <div class="row">
        <div class="col-md-5 order-md-2 mb-4">
          <h4 class="d-flex justify-content-between align-items-center mb-3">
            <span class="text-muted">Your serials</span>
            <span class="badge badge-secondary badge-pill">{{ userSerials && userSerials.length }}</span>
          </h4>
            <li v-for="serial in userSerials" class="list-group-item d-flex justify-content-between lh-condensed">
              <div>
                <h6 class="my-0">{{ serial }}</h6>
                <small class="text-muted">Brief description</small>
              </div>
              <span class="text-muted">2015</span>
              <button type="button" class="btn btn-light" v-on:click="removeUserSerial(serial)">Remove</button>
            </li>  
          </ul>

          <form class="card p-2">
            <label for="firstName">iCal feed</label>            
            <feed-link /> 
          </form>
        </div>
        <div class="col-md-5 order-md-1">
          <h4 class="mb-3">Search new</h4>
          <form class="needs-validation" novalidate>
            <div class="row">
              <search-serial v-on:found = "addUserSerial" />
            </div>
           
          </form>
        </div>
      </div>

      <footer class="my-5 pt-5 text-muted text-center text-small">
        <p class="mb-1">&copy; 2018-2019 Company Noname</p>
      </footer>
      </div>
  `
});