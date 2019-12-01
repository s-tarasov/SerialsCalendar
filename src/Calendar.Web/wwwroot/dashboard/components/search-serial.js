Vue.component('vue-bootstrap-typeahead', VueBootstrapTypeahead)

Vue.component('search-serial', {
  data: function() {
    return {
      query: null,
      queryResults: []
    }
  },
  methods: {
    search: async function(q) {
      this.queryResults = await API.findSerial(q);
    },
    onHit: function(selected) {
      this.$emit('found', selected)
    }
  },
  watch: {
    query: debounce(function(q) {
      this.search(q)
    }, 500)
  },
  template: `
<div class="col-md-6 mb-3">
                <label for="firstName">Serial Name</label>                
                <vue-bootstrap-typeahead
                  placeholder="enter serial name" 
                  v-model="query"
                  @hit="onHit"
                  :data="queryResults"
                />
                <div class="invalid-feedback">
                  ENter serial name.
                </div>
              </div>
  `
});