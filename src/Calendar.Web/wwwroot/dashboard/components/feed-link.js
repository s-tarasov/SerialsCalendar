Vue.component('feed-link', {
  data: function() {
    return {
      url: ""
    }
  },
  methods: {
    copy: function() {
      document.querySelector('#feedLinkInput').select();
      document.execCommand('copy');
    }
  },
  mounted() {
    API.getUserInfo().then((data) => {
      this.url = data.feedLink;
    });
  },
  template: `
<div class="input-group" >              
          <input id="feedLinkInput" type="text" class="form-control" readonly :value="url" >
          <div class="input-group-append">
            <button type="button" class="btn btn-secondary" v-on:click="copy">Copy</button>
          </div>
        </div>
  `
});