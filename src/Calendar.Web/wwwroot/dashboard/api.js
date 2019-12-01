var API = {
	getUserInfo: async function() {
		return {
			"feedLink": window.feedUrl
		};
	},
	getUserSerials: async function() {
		var response = await fetch('/serials/');
		var serials = await response.json();
		return serials.map(s => s.title);
	},
	addUserSerial: async function(serialAlias) {
		await fetch('/serials', {
			method: 'post',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify({ SerialId: serialAlias })
		});
	},
	removeUserSerial: async function(serialAlias) {
		await fetch('/serials/' + serialAlias, {
			method: 'delete'
		});
	},
	findSerial: async function(query) {
		var sourceUrl = "https://api.themoviedb.org/3/search/tv?api_key=fe5f5be42e7abbb3079056701867b87f&query=" +
			encodeURIComponent(query);
		let response = await fetch(sourceUrl);

		if (response.ok) {
			let json = await response.json();
			return json.results.map(r => r.name);
		} else {
			return [];
		}
	},
};