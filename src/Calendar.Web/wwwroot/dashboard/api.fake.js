var API = {
	getUserInfo: function() {
		return delay(1000).then(() => {
			return {
				"feedLink": "https://learn.javascript.ru/task/promise-settimeout"
			}
		});
	},
	getUserSerials: function() {
		return delay(500).then(() => {
			return ["Game of Thrones", "Breaking Bads"]
		});
	},
	addUserSerial: function(serialAlias) {
		console.log('API.addUserSerial=' + serialAlias);
		return delay(100);
	},
	removeUserSerial: function(serialAlias) {
		console.log('API.removeUserSerial=' + serialAlias);
		return delay(100);
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