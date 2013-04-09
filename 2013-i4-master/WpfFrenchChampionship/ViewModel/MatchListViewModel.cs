using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoccerRankingLib;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace WpfFrenchChampionship.ViewModel
{
    class MatchListViewModel :ViewModel
    {
        private ObservableCollection <Match> _matches;
        private Ranking _ranking;

        public MatchListViewModel(Ranking ranking)
        {
            this._matches = new ObservableCollection<Match>();
            this._ranking = ranking;
            this._ranking.NewMatchRegistered += new EventHandler<Ranking.MatchRegistrationEventArgs>(_ranking_NewMatchRegistered);
        }

        void _ranking_NewMatchRegistered(object sender, Ranking.MatchRegistrationEventArgs e)
         {
        Match nouveauMatch = new Match(e.NewMatch.Home , e.NewMatch.Away , e.NewMatch.AwayGoals, e.NewMatch.HomeGoals);
        this._matches.Add(nouveauMatch);

         }

        public ObservableCollection<Match> Matches
        {
            get { return this._matches; }
        } 

    }
}
