﻿using System;
using System.ComponentModel;

namespace StatusCheck
{
    public enum Services
    {
        
        [Description("translation")]
        translation,
        [Description("air-perimeter")]
        air_perimeter,
        [Description("bet-gate")]
        bet_gate,
        [Description("bet-gate-api")]
        bet_gate_api,
        [Description("bet-handler")]
        bet_handler,
        //[Description("bet-processor")]
        //bet_processor,
        //[Description("bet-settlement")]
        //bet_settlement,
        //[Description("bet-settlement-api")]
        //bet_settlement_api,
        [Description("bet-store")]
        bet_store,
        [Description("bet-store-host")]
        bet_store_host,
        [Description("bet-view")]
        bet_view,
        [Description("bethistory-localization")]
        bethistory_localization,
        [Description("betradar-statistics")]
        betradar_statistics,       
        [Description("betstatisticsapi")]
        betstatisticsapi,
        //[Description("cadvisor")]
        //cadvisor,
        [Description("chinch")]
        chinch,
        //[Description("es-fan-desktop")]
        //es_fan_desktop,
        //[Description("esport-afs-proxy")]
        //esport_afs_proxy,
        [Description("esport-backoffice-api")]
        esport_backoffice_api,
        [Description("esport-bet-gate")]
        esport_bet_gate,
        [Description("esport-bet-processor")]
        esport_bet_processor,
        [Description("esport-bet-settlement")]
        esport_bet_settlement,
        [Description("esport-bet-settlement-api")]
        esport_bet_settlement_api,
        [Description("esport-bet-store")]
        esport_bet_store,
        [Description("esport-bet-store-host")]
        esport_bet_store_host,
        [Description("esport-bet-view")]
        esport_bet_view,
        [Description("esport-event-state")]
        esport_event_state,
        [Description("esport-player-history-api")]
        esport_player_history_api,
        //[Description("esport-player-history-host")]
        //esport_player_history_host,
        [Description("esport-selection-results")]
        esport_selection_results,
        [Description("esport-supervisor-monitor-api")]
        esport_supervisor_monitor_api,
        //[Description("esport-supervisor-monitor-host")]
        //esport_supervisor_monitor_host,
        //[Description("event-limit-api")]
        //event_limit_api,
        //[Description("feed-change-tracker")]
        //feed_change_tracker,
        [Description("feed-producer")]
        feed_producer,
        //[Description("fh-esbet")]
        //fh_esbet,
        //[Description("fh-ggbet")]
        //fh_ggbet,
        [Description("fh-live")]
        fh_live,
        [Description("fh-live-esport")]
        fh_live_esport,
        [Description("fh-live-old")]
        fh_live_old,
        [Description("fh-prematch")]
        fh_prematch,
        [Description("fh-prematch-esport")]
        fh_prematch_esport,
        [Description("fh-prematch-old")]
        fh_prematch_old,
        [Description("fh-virtualsports")]
        fh_virtualsports,
        [Description("gryllotran")]
        gryllotran,
        [Description("inner-feed-wrapper-live")]
        inner_feed_wrapper_live,
        [Description("inner-feed-wrapper-live-airpm")]
        inner_feed_wrapper_live_airpm,
        [Description("line-handler")]
        line_handler,
        [Description("lineclient")]
        lineclient,
        //[Description("local-feed-api")]
        //local_feed_api,
        //[Description("player-history-api")]
        //player_history_api,
        [Description("snaillayout")]
        snaillayout,
        [Description("sport-backoffice-api")]
        sport_backoffice_api,
        //[Description("sport-risks-generator")]
        //sport_risks_generator,,
        [Description("sport-schema")]
        sport_schema,
        [Description("spout")]
        spout,
        [Description("spout-prematch")]
        spout_prematch,
        [Description("taxonomy")]
        taxonomy,
        [Description("taxonomy-spout")]
        taxonomy_spout
    }
}