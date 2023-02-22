mergeInto(LibraryManager.library, {

  ShowAds: function(){
    YaGames.init().then(ysdk => ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
    }
    }))
  },

  SaveExtern: function(date){
      var dateString = UTF8ToString(date);
      var myobj = JSON.parse(dateString);
      player.setData(myobj);
  },

  LoadExtern: function(){
      player.getData().then(_date => {
        const myJSON = JSON.stringify(_date);
        myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
      });
  },

  RateGame: function(){
      ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  },

  SetToLeaderboard: function(value) {
    ysdk.getLeaderboards()
      .then(lb => {
      // Без extraData
      lb.setLeaderboardScore('CountOpenWords', value);
    });
  },

  AddCoinsExtern: function(value){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage("CoinManager", "AddCoins", value);
          myGameInstance.SendMessage("CoinManager", "UpdateScreen");
        },
        onClose: () => {
          console.log('Video ad closed.');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
  }

});